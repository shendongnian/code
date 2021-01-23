    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace My.Web.Api.OpenXml
    {
        public static class WordTools
        {
            
            /// <summary>
            /// Search within an open XML element for any paragraphs in it's children or descendants that contain the 'find' text within the paragraph.
            /// ('find' may not contain line breaks).
            /// Replace the search text with the text of 'replaceWith', using the formatting of the first run 
            /// (other runs have text cleared if the find text spanned multiple runs).
            /// 'replaceWith' MAY contain line breaks, which will be added as new elements.
            /// </summary>
            /// <param name="searchInElement"></param>
            /// <param name="find"></param>
            /// <param name="replaceWith"></param>
            public static void ReplaceText(OpenXmlElement searchInElement, string find, string replaceWith)
            {
                // strip out high-level unicode chars that may not render correctly in the document
                replaceWith = OpenXmlTools.RemoveInvalidXMLChars(replaceWith);
    
                foreach (var paragraph in searchInElement.Descendants<Paragraph>().Where(p => p.InnerText.Contains(find)))
                {   // all paragraphs containing the text
                    var texts = paragraph.Descendants<Text>();
                    for (int t = 0; t < texts.Count(); t++)
                    {   // figure out which Text element within the paragraph contains the starting point of the search string
                        Text txt = texts.ElementAt(t);
                        for (int c = 0; c < txt.Text.Length; c++)
                        {
                            var match = IsMatch(texts, t, c, find);
                            if (match != null)
                            {   // now replace the text
                                string[] lines = replaceWith.Replace(Environment.NewLine, "\r").Split('\n', '\r'); // handle any lone n/r returns, plus newline.
                                replaceWith = lines[0];
    
                                if (c > 0)
                                    replaceWith = txt.Text.Substring(0, c) + replaceWith;  // has a prefix
                                if (match.EndCharIndex + 1 < texts.ElementAt(match.EndElementIndex).Text.Length)
                                    replaceWith = replaceWith + texts.ElementAt(match.EndElementIndex).Text.Substring(match.EndCharIndex + 1);
    
                                txt.Space = new EnumValue<SpaceProcessingModeValues>(SpaceProcessingModeValues.Preserve); // in case your value starts/ends with whitespace
                                txt.Text = replaceWith;
    
                                // remove any extra texts.
                                for (int i = t + 1; i <= match.EndElementIndex; i++)
                                {
                                    texts.ElementAt(i).Text = string.Empty; // clear the text
                                }
    
                                // if 'with' contained line breaks we need to add breaks back...
                                if (lines.Count() > 1)
                                {
                                    OpenXmlElement currEl = txt;
                                    Break br;
                                    Text nextLine;
                                    // append more lines
                                    var run = txt.Parent as Run;
                                    for (int i = 1; i < lines.Count(); i++)
                                    {
                                        br = new Break();
                                        run.InsertAfter<Break>(br, currEl);
                                        currEl = br;
                                        nextLine = new Text(lines[i]);
                                        run.InsertAfter<Text>(nextLine, currEl);
                                        currEl = nextLine;
                                    }
                                }
                            }
                        }
                    }
                }
                return;
            }
    
            /// <summary>
            /// Determine if the texts (starting at element t, char c) exactly contain the find text
            /// </summary>
            /// <param name="texts"></param>
            /// <param name="t"></param>
            /// <param name="c"></param>
            /// <param name="find"></param>
            /// <returns>null or the result info</returns>
            static Match IsMatch(IEnumerable<Text> texts, int t, int c, string find)
            {
                int ix = 0;
                for (int i = t; i < texts.Count(); i++)
                {
                    for (int j = c; j < texts.ElementAt(i).Text.Length; j++)
                    {
                        if (find[ix] != texts.ElementAt(i).Text[j])
                        {
                            return null; // element mismatch
                        }
                        ix++; // match; go to next character
                        if (ix == find.Length)
                            return new Match() { EndElementIndex = i, EndCharIndex = j }; // full match with no issues
                    }
                    c = 0; // reset char index for next text element
                }
                return null; // ran out of text, not a string match
            }
    
            /// <summary>
            /// Defines a match result
            /// </summary>
            class Match
            {
                /// <summary>
                /// Last matching element index containing part of the search text
                /// </summary>
                public int EndElementIndex { get; set; }
                /// <summary>
                /// Last matching char index of the search text in last matching element
                /// </summary>
                public int EndCharIndex { get; set; }
            }
    
         }   // class
    }  // namespace
    public static class OpenXmlTools
        {
            // filters control characters but allows only properly-formed surrogate sequences
            private static Regex _invalidXMLChars = new Regex(
                @"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]",
                RegexOptions.Compiled);
            /// <summary>
            /// removes any unusual unicode characters that can't be encoded into XML which give exception on save
            /// </summary>
            public static string RemoveInvalidXMLChars(string text)
            {
                if (string.IsNullOrEmpty(text)) return "";
                return _invalidXMLChars.Replace(text, "");
            }
        }
