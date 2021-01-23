        private string ExtractBetweenBodyTags(string str1)
        {
            if ( ! string.IsNullOrEmpty(str1))
            {
                int p1 = str1.IndexOf("<body>\r\n");
                    if (p1 >-1)
                    {
                        string str2 = str1.Substring(p1 + "<body>\r\n".Length);
                        int p2= str2.IndexOf("\r\n</body>");
                        if (p2 > -1)
                        {
                            str2 = str2.Substring(0,p2-1 );
                            return str2;
                        }
                    }
            }
            return "";
        }
