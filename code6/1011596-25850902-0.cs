    public static void LogMessage(string sFilePath, string sMsg)
            {
                using (StreamWriter sw = File.AppendText(sFilePath))
                {
                    sw.WriteLine(string.Format(@"{0} : {1}", DateTime.Now.ToLongTimeString(), sMsg));
                }
            }
