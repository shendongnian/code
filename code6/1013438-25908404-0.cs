            private static void ClearLog()
        {
            string logfp = _AppPath + @"\Logging";
            try
            {
                if (File.Exists(logfp + @"\Log2.txt"))
                {
                    File.Delete(logfp + @"\Log2.txt");
                    if (File.Exists(logfp + @"\Log1.txt"))
                    {
                        File.Copy(logfp + @"\Log1.txt", logfp + @"\Log2.txt");
                        File.Delete(logfp + @"\Log1.txt");
                    }
                    else
                    {
                        File.AppendAllText(logfp + @"\Log1.txt", "New Log created: " + DateTime.Now.ToString());//showing you when it was created
                    }
                }
                else
                {
                    File.Copy(logfp + @"\Log1.txt", logfp + @"\Log2.txt");
                    File.Delete(logfp + @"\Log1.txt");
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("Clear log failed " + ex.ToString());
            }
        }
