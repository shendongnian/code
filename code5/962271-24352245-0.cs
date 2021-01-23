            /// <summary>
        /// 
        /// </summary>
        /// <param name="YouTubeVideoSignatureEncoded">encoded youtube signature</param>
        /// <param name="html5playerJScode">html5player-(.+?)\.js</param>
        /// <returns></returns>
        public string DecodeYouTubeSignature(string YouTubeVideoSignatureEncoded, string html5playerJScode)
        {
            //JScode=html5player javascript code
            string Function_Name = GetBetweenInString(html5playerJScode, ".signature=$", "(");
            //find the decoder function line
            string functionLine = GetBetweenInString(html5playerJScode, "function $" + Function_Name, "};");
            string[] Lines = functionLine.Split(';');
            for (int i = 0; i <= Lines.Length - 1; i++)
            {
                string Line = Lines[i].Trim();
                string jsVariable = GetBetweenInString(Line, "(", ")").Trim();
                if (Line.ToLower().Contains(".reverse"))
                {
                    char[] charArray = YouTubeVideoSignatureEncoded.ToCharArray();
                    Array.Reverse(charArray);
                    YouTubeVideoSignatureEncoded = new string(charArray);
                }
                else if (Line.ToLower().Contains(".slice"))
                {
                    YouTubeVideoSignatureEncoded = YouTubeVideoSignatureEncoded.Substring(Convert.ToInt32(jsVariable));
                }
            }
            return YouTubeVideoSignatureEncoded;// return decoded signature if possible.
        }
        /// <summary>
        /// string stackoverflow = GetBetweenInString("http://stackoverflow.com", "http://", ".com");
        /// </summary>
        /// <param name="str">http://stackoverflow.com</param>
        /// <param name="fromStr">http://</param>
        /// <param name="toStr">.com</param>
        /// <returns>stackoverflow</returns>
        public string GetBetweenInString(string str, string fromStr, string toStr)
        {
            try
            {
                if (string.IsNullOrEmpty(str) == true)
                    return "";
                if (string.IsNullOrEmpty(fromStr) == true)
                    return "";
                if (string.IsNullOrEmpty(toStr) == true)
                    return "";
                string[] R = System.Text.RegularExpressions.Regex.Split(str, fromStr);
                if (R.Length == 1)
                    return "";
                string[] R1 = System.Text.RegularExpressions.Regex.Split(R[1], toStr);
                if (R1.Length == 1)
                {
                    return "";
                }
                else
                {
                    return R1[0];
                }
            }
            catch
            {
                return "";
            }
        }
 
