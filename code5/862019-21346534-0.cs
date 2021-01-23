        public static List<string> ExtractUrls(string html)
        {
            string title = GetTitle(html);
            List<string> urls = new List<string>();
            string DataBlockStart = "\"url_encoded_fmt_stream_map\":\\s+\"(.+?)&";  // Marks start of Javascript Data Block
            html = Uri.UnescapeDataString(Regex.Match(html, DataBlockStart, RegexOptions.Singleline).Groups[1].ToString());
            string firstPatren = html.Substring(0, html.IndexOf('=') + 1);
            var matchs = Regex.Split(html, firstPatren);
            for (int i = 0; i < matchs.Length; i++)
                matchs[i] = firstPatren + matchs[i];
            foreach (var match in matchs)
            {
                if (!match.Contains("url=")) continue;
                string url = GetTxtBtwn(match, "url=", "\\u0026", 0, false);
                if (url == "") url = GetTxtBtwn(match, "url=", ",url", 0, false);
                if (url == "") url = GetTxtBtwn(match, "url=", "\",", 0, false);
                string sig = GetTxtBtwn(match, "sig=", "\\u0026", 0, false);
                if (sig == "") sig = GetTxtBtwn(match, "sig=", ",sig", 0, false);
                if (sig == "") sig = GetTxtBtwn(match, "sig=", "\",", 0, false);
                while ((url.EndsWith(",")) || (url.EndsWith(".")) || (url.EndsWith("\"")))
                    url = url.Remove(url.Length - 1, 1);
                while ((sig.EndsWith(",")) || (sig.EndsWith(".")) || (sig.EndsWith("\"")))
                    sig = sig.Remove(sig.Length - 1, 1);
                if (string.IsNullOrEmpty(url)) continue;
                if (!string.IsNullOrEmpty(sig))
                    url += "&signature=" + sig;
                urls.Add(url);
            }
            for (int i = 0; i < urls.Count; i++)
            {
                urls[i] += "&title=";
                urls[i] += title;
            }
            
            return urls;
        }
        public static string GetTitle(string RssDoc)
        {
            string str14 = GetTxtBtwn(RssDoc, "'VIDEO_TITLE': '", "'", 0, false);
            if (str14 == "") str14 = GetTxtBtwn(RssDoc, "\"title\" content=\"", "\"", 0, false);
            if (str14 == "") str14 = GetTxtBtwn(RssDoc, "&title=", "&", 0, false);
            str14 = str14.Replace(@"\", "").Replace("'", "&#39;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("+", " ");
            return str14;
        }
        public static string GetTxtBtwn(string input, string start, string end, int startIndex, bool UseLastIndexOf)
        {
            int index1 = UseLastIndexOf ? input.LastIndexOf(start, startIndex) :
                                          input.IndexOf(start, startIndex);
            if (index1 == -1) return "";
            index1 += start.Length;
            int index2 = input.IndexOf(end, index1);
            if (index2 == -1) return input.Substring(index1);
            return input.Substring(index1, index2 - index1);
        }
