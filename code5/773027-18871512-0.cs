        public static string ReadWordFile(string strFilePath, Extension objExtension)
        {
            string strFileContent = string.Empty;
            try
            {
                if (objExtension == Extension.WebPage)
                {
                    try
                    {
                        Open(strFilePath);
                        strFileContent = ClsCommon.HTMLBody(ClsCommon.ReadFile(SaveAs(strFilePath, HtmExtension, WdSaveFormat.wdFormatFilteredHTML), true));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return strFileContent;
        }
          private static string SaveAs(string FilePath, string strFileExtension,    WdSaveFormat objSaveFormat)
        {
            try
            {
                FilePath = System.IO.Path.ChangeExtension(FilePath, strFileExtension);
                doc.SaveAs(FilePath, objSaveFormat, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing, objMissing);
            }
            catch
            {
            }
            finally
            {
                Close();
            }
            return FilePath;
        }
        public static string HTMLBody(string strHTML)
        {
            strHTML = ClearHTMLContent(strHTML);
            if (strHTML.ToLower().IndexOf("<body") > 0 && strHTML.ToLower().IndexOf("</body>") > 0)
            {
                strHTML = strHTML.Substring(strHTML.ToLower().IndexOf("<body") + 5, strHTML.ToLower().IndexOf("</body>") - (strHTML.ToLower().IndexOf("<body") + 5));
                strHTML = strHTML.Substring(strHTML.IndexOf(">") + 1, strHTML.Length - (strHTML.IndexOf(">") + 1));
            }
            return strHTML;
        }
        public static string ClearHTMLContent(string Str)
        {
            if (Str.ToLower().IndexOf("<base") > 0)
            {
                Str = Str.Replace(Str.Substring(Str.ToLower().IndexOf("<base"), Str.Substring(Str.ToLower().IndexOf("<base")).IndexOf(">") + 1), "");
            }
            return Str.Replace("Â", "").Replace("�", "");
        }
