        /// <summary>
        /// Generates the sound file using SoX.exe.
        /// </summary>
        /// <param name="fromFile">From file in uLaw encoding.</param>
        /// <param name="toFile">To wav file.</param>
        public bool GenerateSoundFile(string fromFile, string toFile)
        {
            string log = string.Format("fromFile={0},toFile={1}", fromFile, toFile);
            EventLogger.Log(log);
            string arguments;
            //check the extension
            string ext = Path.GetExtension(fromFile);
            if (ext == ".ulaw")
            {
                arguments = string.Format("-t ul {0} -c 1 -r 8000 {1}", fromFile, toFile);
            }
            else
            {
                arguments = string.Format(" {0} -c 1 -r 8000 {1}", fromFile, toFile);
            }
            EventLogger.Log(arguments);
            string command = System.Environment.CurrentDirectory + "\\sox.exe";
            try
            {   
			    Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = command;
                p.StartInfo.Arguments = arguments;
                p.StartInfo.LoadUserProfile = true;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception e)
            {
                EventLogger.Error("GenerateSoundFile", e);
            }
            //check output file exists           
            if (!File.Exists(toFile))
            {
                EventLogger.Error("No output sound file generated");
                return false;
            }
            else
            {
                return true;
            }
        }
