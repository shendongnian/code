    void Session_Start(object sender, EventArgs e) 
        {
         System.IO.FileStream logFile = new System.IO.FileStream((String)Application["logPath"] + System.IO.Path.DirectorySeparatorChar + "log.txt",
                    System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter logWriter = new System.IO.StreamWriter(logFile);
            logWriter.WriteLine("---- Sessoion started on " + DateTime.Now.ToString());
            logWriter.Close();
            logFile.Close();
        }
    void Session_End(object sender, EventArgs e) 
        {
            System.IO.FileStream logFile = new System.IO.FileStream((String)Application["logPath"] + System.IO.Path.DirectorySeparatorChar + "log.txt",
                    System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter logWriter = new System.IO.StreamWriter(logFile);
            logWriter.WriteLine("---- Sessoion ended on " + DateTime.Now.ToString());
            logWriter.Close();
            logFile.Close();
        }
