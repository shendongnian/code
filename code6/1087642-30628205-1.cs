    private void button1_Click(object sender, EventArgs e)
            {
                //For internet explorer
                System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
    
                // for Google Chrome.
                string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
                string userName = Environment.UserName; // for getting user name
    
                  // first close all the extension of chrome (close all the chrome browser which are opened)
    
                try
                {
                    Process[] Path1 = Process.GetProcessesByName("chrome");
                    foreach (Process p in Path1)
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                        p.WaitForExit();
                        p.Dispose();
                    }
    
                    
                    System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(rootDrive + "Users\\"+userName+"\\AppData\\Local\\Google\\Chrome\\User Data");
    
    
                    try
                    {
                        foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                        {
                            file.Delete();
                        }
                    }
                    catch { }
    
                    try
                    {
                        foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    catch { }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    label1.Text = " History Deleted successfully.";
            }
