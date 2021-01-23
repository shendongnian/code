     public static class Helper
        {
            public static string UnicodeToUglycode(string unicodeString, string lang)
            {
    
                var ansiCodePage = GetCodepage(lang);
    
                var unicode = Encoding.Unicode;
                var ansi = Encoding.GetEncoding(ansiCodePage);
             
                var bytesUnicode = unicode.GetBytes(unicodeString);          
                var bytesansi = Encoding.Convert(unicode, ansi, bytesUnicode);
                
                // try udly recoding lie WSS
                var uglycode = AnsiToUglycode(bytesansi);
    
                return uglycode; 
            }        
    
    
            /// <summary>
            /// This is done as ugly Windows Search Service do
            /// </summary>
            /// <param name="ansiBytes">Correct ansi values</param>
            /// <returns>ugly converted to unicode string</returns>
            public static string AnsiToUglycode(byte[] ansiBytes)
            {
                var builder = new StringBuilder();
                for (int i = 0; i < ansiBytes.Length; i++)
                {
                    var ch = ansiBytes[i].ToString("X2");
                    ch = ch.Insert(0, "00");
                    int value = Convert.ToInt32(ch, 16);
                    builder.Append(Char.ConvertFromUtf32(value));                
                }
    
                var ugly = builder.ToString();
                return ugly;
            }    
    
            public static int GetLcid(string lang)
            {
                var cultureInfo = CultureInfo.GetCultureInfo(lang);
                return cultureInfo.TextInfo.LCID;
            }
    
            public static int GetCodepage(string lang)
            {
                var cultureInfo = CultureInfo.GetCultureInfo(lang);
                return cultureInfo.TextInfo.ANSICodePage;
            }
        }
