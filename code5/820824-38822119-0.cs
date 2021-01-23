     public static class LogWriter
            {
                private static string m_exePath = string.Empty;
                public static void LogWrite(string logMessage)
                {
                    m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    if (!File.Exists(m_exePath + "\\" + "log.txt"))
                        File.Create(m_exePath + "\\" + "log.txt");
        
                    try
                    {
                        using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                            AppendLog(logMessage, w);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
        
                }
        
                private static void AppendLog(string logMessage, TextWriter txtWriter)
                {
                    try
                    {
                        txtWriter.Write("\r\nLog Entry : ");
                        txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
                        txtWriter.WriteLine("  :");
                        txtWriter.WriteLine("  :{0}", logMessage);
                        txtWriter.WriteLine("-------------------------------");
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
