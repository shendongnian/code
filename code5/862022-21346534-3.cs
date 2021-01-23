        public static string GetFLV(List<string> urls)
        {
            // Acquire a list of links which match the criteria for being FLV files
            List<string> flvurls = new List<string>();
            foreach (string url in urls)
            {
                string itag = Regex.Match(url, @"itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups[1].ToString();
                int itagint;
                int.TryParse(itag, out itagint);
                
                if (itagint == 5 || itagint == 6 || itagint == 34 || itagint == 35)
                {
                    flvurls.Add(url);
                }
            }
            // If we didn't find any FLVs, we return a fatal error and cause a bug later on
            if (flvurls.Count == 0)
            {
                MessageBox.Show("Fatal error | iTag could not be found for FLV filetype. Please contact software vendor for assistance.");
                return "";
            }
            // If we did find some FLVs, we need to find the highest quality FLV
            else
            {
                #region findBestFLV
                foreach (string url in flvurls)
                {
                    string itag = Regex.Match(url, @"itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups[1].ToString();
                    int itagint;
                    int.TryParse(itag, out itagint);
                    if (itagint == 35)
                    {
                        return url;
                    }
                }
                foreach (string url in flvurls)
                {
                    string itag = Regex.Match(url, @"itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups[1].ToString();
                    int itagint;
                    int.TryParse(itag, out itagint);
                    if (itagint == 34)
                    {
                        return url;
                    }
                }
                foreach (string url in flvurls)
                {
                    string itag = Regex.Match(url, @"itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups[1].ToString();
                    int itagint;
                    int.TryParse(itag, out itagint);
                    if (itagint == 6)
                    {
                        return url;
                    }
                }
                foreach (string url in flvurls)
                {
                    string itag = Regex.Match(url, @"itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups[1].ToString();
                    int itagint;
                    int.TryParse(itag, out itagint);
                    if (itagint == 5)
                    {
                        return url;
                    }
                }
                #endregion
            }
            MessageBox.Show("Fatal error | Something has gone horrible wrong whilst finding the best FLV to use. Run, brave warrior, for the end is near.");
            return "";
        }
