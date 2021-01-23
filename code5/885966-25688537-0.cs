    protected void Build(string project)
        {
            Engine engine = new Engine();
            BuildPropertyGroup properties = new BuildPropertyGroup();
            properties.SetProperty(@"Configuration", @"Debug");
            // Point to the path that contains the .NET Framework 2.0 CLR and tools
            engine.BinPath = @"c:\windows\microsoft.net\framework\v3.5";
            // Instantiate a new FileLogger to generate build log
            FileLogger logger = new FileLogger();
            // Set the logfile parameter to indicate the log destination
            string str   = @"logfile=D:\temp";
                   str  += project.Substring(project.LastIndexOf("\\"), project.LastIndexOf(".") - project.LastIndexOf("\\")) + ".log";
            logger.Parameters = str;
            // Register the logger with the engine
            engine.RegisterLogger(logger);
          
            // Build a project file
            bool success = engine.BuildProjectFile(project, new string[] { "build" }, properties);
            //Unregister all loggers to close the log file
            engine.UnregisterAllLoggers();
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"D:\temp\Prj.log", FileMode.Append)))
            {
                if (success)
                {
                    writer.Write("\nBuild Success :" + project.Substring(project.LastIndexOf("\\")));
                }
                else
                {
                    writer.Write("\nBuild Fail :" + project.Substring(project.LastIndexOf("\\")));
                }
            }
        }
