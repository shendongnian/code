    public static class ClientScriptManagerExtensions
    {
        /// <summary>
        /// Registers the startup script with the <see cref="Page"/> object using a type,
        /// a key, and a url
        /// </summary>
        /// <param name="source">
        /// The <see cref="ClientScriptManager"/> with which the script should be registered
        /// </param>
        /// <param name="type">The type of startup script to register</param>
        /// <param name="key">The key of the startup script to register</param>
        /// <param name="url">The url of the startup script include to register</param>
        public static void RegisterStartupScriptInclude(this ClientScriptManager source,
                                                        Type type,
                                                        string key,
                                                        string url)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var script = string.Format(@"<script src=""{0}""></script>", HttpUtility.HtmlEncode(url));
            source.RegisterStartupScript(type, key, script);
        }
    }
