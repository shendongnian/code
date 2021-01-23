    private readonly object logLock = new object();
    protected void Print_To_LogScreen(string Text, bool NewLine)
    {
        if (InvokeRequired)
            Invoke(new DPrint_To_LogScreen(Print_To_LogScreen), new object[] { Text, NewLine }); // exception thrown here from the Text string 
        else
        {
            lock (logLock)
            {
                LogScreen.AppendText(Convert.ToString(DateTime.Now) + "  ->  " + Text + (NewLine ? System.Environment.NewLine : ""));
                if (Log_Screen_File == null)
                {
                    using (Log_Screen_File = new StreamWriter(@"Global.log", true))
                    {
                        Log_Screen_File.WriteLine(Convert.ToString(DateTime.Now) + "  ->  " + Text);
                    }
                    Log_Screen_File = null;
                }
                else
                {
                    Log_Screen_File.WriteLine(Convert.ToString(DateTime.Now) + "  ->  " + Text);
                }
            }
        }
    }
