        static string CleanNonFormattingFromRtf(string rtf)
        {
            var rsidRegex = new Regex("(rsid[0-9]+)");
            var cleanText = rtf;
            cleanText = RemoveRtfGroup(cleanText, @"*\datastore");
            cleanText = RemoveRtfGroup(cleanText, @"*\rsidtbl");
            cleanText = rsidRegex.Replace(cleanText, string.Empty);
            return cleanText;
        }
