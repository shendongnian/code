     void Application_Start(object sender, EventArgs e) 
        {
            // Code that runs on application startup
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path="~/Scripts/jquery-1.11.0.js"
            });
            Application.Add("logPath", Server.MapPath("Log"));
            System.IO.FileStream logFile = new System.IO.FileStream((String)Application["logPath"] + System.IO.Path.DirectorySeparatorChar + "log.txt",
                    System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter logWriter = new System.IO.StreamWriter(logFile);
            logWriter.WriteLine(">>>>>> Application started on " + DateTime.Now.ToString());
            logWriter.Close();
            logFile.Close();
        }
