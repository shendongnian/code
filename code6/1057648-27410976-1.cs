        public void FixLinks()
        {
            var input = editorWebBrowser.DocumentText;
            // this regex will match all href="about: ... " links
            const string hrefLinks = @"href\s?=\s?([""'])about:.*?\1";
            const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            // the key to doing it all in "one step" is calling ReplaceCruft delegate for every match
            var result = Regex.Replace(input, hrefLinks, ReplaceCruft, options);
            Html = result;
        }
        /// <summary>
        ///     Replaces "about:" and "amp;" text with an empty string in regular expression matches.
        ///     This corrects the WebControl munging the links when they're relative and ampersand escaping.
        /// </summary>
        /// <param name="match">
        ///     An href="about:..." link that needs un-munging.
        /// </param>
        /// <returns>
        ///     A string without the about: prefix and & characters instead of &amp;
        /// </returns>
        private static string ReplaceCruft(Match match)
        {
            var input = match.Value;
            const string pattern = @"about:|amp;";
            const string replacement = "";
            const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
            var result = Regex.Replace(input, pattern, replacement, options);
            return result;
        }
