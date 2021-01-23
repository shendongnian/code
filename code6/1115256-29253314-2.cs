     public static void WriteCustomLog(string msg)
                {
                    FileStream fs = null;
                    StreamWriter sw = null;
                    FileStream fs1 = null;
                    StreamWriter sw1 = null;
                    try
                    {
                        //check and make the directory if necessary; this is set to look in the application
                        //folder, you may wish to place the error log in another location depending upon the
                        //the user's role and write access to different areas of the file system
                        if (!System.IO.Directory.Exists(Application.StartupPath + "\\Log\\"))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Log\\");
        
                        string date = DateTime.Now.ToString("dd_MM_yyyy");
        
                        //check the file
                        fs = new FileStream(Application.StartupPath + "\\Log\\Log" + date + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        sw = new StreamWriter(fs);
                        sw.Close();
                        fs.Close();
        
                        //log it
                        fs1 = new FileStream(Application.StartupPath + "\\Log\\Log" + date + ".txt", FileMode.Append, FileAccess.Write);
                        sw1 = new StreamWriter(fs1);
                        sw1.Write(DateTime.Now.ToString() + " Message: " + msg + Environment.NewLine);
                        sw1.Write("Date/Time: " + DateTime.Now.ToString() + Environment.NewLine);
                        sw1.Write("=======================================================" + Environment.NewLine);
        
                    }
    }
