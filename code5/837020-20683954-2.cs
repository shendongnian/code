    namespace YourNameSpace
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Text;
        using System.Web;
        /// <summary>
        /// Replaces all uris within in an html document to physical paths, making it valid
        /// html outside the context of a web site. This is necessary because outside the
        /// context of a web site root folder, the uris are meaningless, and the html cannot
        /// be interpreted correctly by external components, like ABCPDF or iTextSharp. 
        /// Without this step, the images and other 'SRC' references cannot be resolved.
        /// </summary>
        public sealed class HtmlRelativeToPhysicalPathConverter
        {
            #region FIELDS
            /// <summary>
            /// The _server.
            /// </summary>
            private readonly HttpServerUtility _server;
            /// <summary>
            /// The _html.
            /// </summary>
            private readonly string _html;
            #endregion
            #region CONSTRUCTOR
            /// <summary>
            /// Initialises a new instance of the <see cref="HtmlRelativeToPhysicalPathConverter"/> class.
            /// </summary>
            /// <param name="server">
            /// The server.
            /// </param>
            /// <param name="html">
            /// The html.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// when <paramref name="server"/> or <paramref name="html"/> is null or empty.
            /// </exception>
            public HtmlRelativeToPhysicalPathConverter(HttpServerUtility server, string html)
            {
                if (null == server) throw new ArgumentNullException("server");
                if (string.IsNullOrWhiteSpace(html)) throw new ArgumentNullException("html");
                _server = server;
                _html = html;
            }
            #endregion
            #region Convert Html
            /// <summary>
            /// Convert the html.
            /// </summary>
            /// <param name="leaveUrisIfFileCannotBeFound">an additional validation can be performed before changing the uri to a directory path</param>
            /// <returns>The converted html with physical paths in all uris.</returns>
            public string ConvertHtml(bool leaveUrisIfFileCannotBeFound = false)
            {
                var htmlBuilder = new StringBuilder(_html);
                // Double quotes
                foreach (var relativePath in this.GetRelativePaths(htmlBuilder, '"'))
                {
                    this.ReplaceRelativePath(htmlBuilder, relativePath, leaveUrisIfFileCannotBeFound);
                }
                // Single quotes
                foreach (var relativePath in this.GetRelativePaths(htmlBuilder, '\''))
                {
                    this.ReplaceRelativePath(htmlBuilder, relativePath, leaveUrisIfFileCannotBeFound);
                }
                return htmlBuilder.ToString();
            }
            #endregion
            #region Replace Relative Path
            /// <summary>
            /// Convert a uri to the physical path.
            /// </summary>
            /// <param name="htmlBuilder">The html builder.</param>
            /// <param name="relativePath">The relative path or uri string.</param>
            /// <param name="leaveUrisIfFileCannotBeFound">an additional validation can be performed before changing the uri to a directory path</param>
            private void ReplaceRelativePath(StringBuilder htmlBuilder, string relativePath, bool leaveUrisIfFileCannotBeFound)
            {
                try
                {
                    var parts = relativePath.Split('?');
                    var mappedPath = _server.MapPath(parts[0]);
                    if ((leaveUrisIfFileCannotBeFound && File.Exists(mappedPath)) || !leaveUrisIfFileCannotBeFound)
                    {
                        if (parts.Length > 1)
                        {
                            mappedPath += "?" + parts[1];
                        }
                        htmlBuilder.Replace(relativePath, mappedPath);
                    }
                    else
                    {
                        /* decide what you want to do with these */
                    }
                }
                catch (ArgumentException)
                {
                    /* ignore these */
                }            
            }
            #endregion
            #region Get Relative Paths
            /// <summary>
            /// They are NOT guaranteed to be valid uris, simply values between quote characters.
            /// </summary>
            /// <param name="html">the html builder</param>
            /// <param name="quoteChar">the quote character to use, e.g. " or '</param>
            /// <returns>each of the relative paths</returns>
            private IEnumerable<string> GetRelativePaths(StringBuilder html, char quoteChar)
            {
                var position = 0;
                var oldPosition = -1;
                var htmlString = html.ToString();
                var previousUriString = string.Empty;
                while (oldPosition != position)
                {
                    oldPosition = position;
                    position = htmlString.IndexOf(quoteChar, position + 1);
                    if (position == -1) break;
                    var uriString = htmlString.Substring(oldPosition + 1, (position - oldPosition) - 1);
                    if (Uri.IsWellFormedUriString(uriString, UriKind.Relative)
                        && uriString != previousUriString
                        /* as far as I know we never reference a file without an extension, so avoid the IDs this way */
                        && uriString.Contains(".") && !uriString.EndsWith("."))
                    {
                        yield return uriString;
                        /* refresh the html string, and reiterate again */
                        htmlString = html.ToString();
                        position = oldPosition;
                        oldPosition = position - 1; /* don't exit yet */
                        previousUriString = uriString;
                    }
                }
            }
            #endregion
        }
    }
