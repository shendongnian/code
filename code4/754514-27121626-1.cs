        const string cabwizpath = @"C:\Program Files (x86)\Microsoft Visual Studio 9.0\SmartDevices\SDK\SDKTools\cabwiz.exe";
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Aborted: You must enter the inf file information");
                Console.ReadLine();
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Aborted: I can not found the INF file!");
                Console.ReadLine();
                return;
            }
            // string to search
            Regex R = new Regex("\"[A-Z]{2,3}_(.+)\\.resources\\.dll\",\"([A-Z]{2,3})_(.+)\\.resources\\.dll\"");
            // File reading
            string inffile = File.ReadAllText(args[0]);
            // Format replace from
            // "FR_ProjectName.resources.dll","FR_ProjectName.resources.dll"
            // To
            // "ProjectName.resources.dll","FR_ProjectName.resources.dll"
            inffile = R.Replace(inffile, "\"$1.resources.dll\",\"$2_$3.resources.dll\"");
            // Rewriting file
            File.WriteAllText(args[0], inffile);
            Console.WriteLine("INF file patched ...");
            // Génération du CAB ...
            Console.WriteLine("Generating correct CAB ... ");
            System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo("\"" + cabwizpath + "\"", "\"" + args[0] + "\"");
            proc.ErrorDialog = true;
            proc.UseShellExecute = false;
            proc.RedirectStandardOutput = true;
            Process CabWiz =  Process.Start(proc);
            Console.WriteLine("\""+cabwizpath + "\" \""+ args[0]+"\"");
            CabWiz.WaitForExit();
            Console.WriteLine("CAB file generated (" + CabWiz.ExitCode + ") !");
        }
