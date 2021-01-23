        {
            var text = @"Started MM/DD/YY HH:MM:SS
    Download1 - success
    Download2 - success
    Download3 - success
    Download4 - success
    Download5 - success
    Download6 - success
    Download7 - success
    Download8 - success
    Ended MM/DD/YY HH:MM:SS";
            var result = IsValid(text, 8);  // you can set the number of "Download.." strings
        }
...
        private static bool IsValid(string text, int countOfDownloads)
        {
            string[] lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            return IsValid(lines,  countOfDownloads);
        }
        private static bool IsValid(string[] lines, int countOfDownloads)
        {
            if (lines.Length != countOfDownloads + 2)
                return false;
            if (!lines[0].StartsWith("Started"))
                return false;
            if (!lines[lines.Length - 1].StartsWith("Ended"))
                return false;
            for (var i = 1; i <= countOfDownloads; i++)
            {
                if (!lines[i].Trim().EndsWith("success"))
                    return false;
            }
            return true;
        }
