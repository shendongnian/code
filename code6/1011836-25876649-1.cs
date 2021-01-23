        /// <summary>
        /// Remove a group from the incoming RTF string starting with {\groupBeginningControlWord
        /// </summary>
        /// <param name="rtf"></param>
        /// <param name="groupBeginningControlWord"></param>
        /// <returns></returns>
        static string RemoveRtfGroup(string rtf, string groupBeginningControlWord)
        {
            // see http://www.biblioscape.com/rtf15_spec.htm
            string groupBeginning = "{\\" + groupBeginningControlWord;
            int index;
            while ((index = rtf.IndexOf(groupBeginning)) >= 0)
            {
                int nextIndex = index + groupBeginning.Length;
                for (int depth = 1; depth > 0 && nextIndex < rtf.Length; nextIndex++)
                {
                    if (rtf[nextIndex] == '}')
                        depth--;
                    else if (rtf[nextIndex] == '{')
                        depth++;
                    if (depth == 0)
                        rtf = rtf.Remove(index, nextIndex - index + 1);
                }
            }
            return rtf;
        }
        static string CleanNonFormattingFromRtf(string rtf)
        {
            var rsidRegex = new Regex("(rsid[0-9]+)");
            var cleanText = rsidRegex.Replace(rtf, string.Empty);
            cleanText = RemoveRtfGroup(cleanText, @"*\datastore");
            return cleanText;
        }
