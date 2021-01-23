    static class Program
    {
        private const string DELETED_FILES_SUBFOLDER = "__delete";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        [STAThread]
        static int Main()
        {
            // Check if shadow copying is already enabled
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                // Get the startup path.
                string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
                string assemblyFile = Path.GetFileName(assemblyPath);
                // Check deleted files folders existance
                string deletionDirectory = Path.Combine(assemblyDirectory, DELETED_FILES_SUBFOLDER);
                if (Directory.Exists(deletionDirectory))
                {
                    // Delete old files from this folder
                    foreach (var oldFile in Directory.EnumerateFiles(deletionDirectory, String.Format("{0}_*{1}", Path.GetFileNameWithoutExtension(assemblyFile), Path.GetExtension(assemblyFile))))
                    {
                        File.Delete(Path.Combine(deletionDirectory, oldFile));
                    }
                }
                else
                {
                    Directory.CreateDirectory(deletionDirectory);
                }
                // Move the current assembly to the deletion folder.
                string movedFileName = String.Format("{0}_{1:yyyyMMddHHmmss}{2}", Path.GetFileNameWithoutExtension(assemblyFile), DateTime.Now, Path.GetExtension(assemblyFile));
                string movedFilePath = Path.Combine(assemblyDirectory, DELETED_FILES_SUBFOLDER, movedFileName);
                File.Move(assemblyPath, movedFilePath);
                // Copy the file back
                File.Copy(movedFilePath, assemblyPath);
                bool reload = true;
                while (reload)
                {
                    // Create the setup for the new domain
                    AppDomainSetup setup = new AppDomainSetup();
                    setup.ApplicationName = assemblyFile;
                    setup.ShadowCopyFiles = true.ToString().ToLowerInvariant();
                    // Create an application domain. Run 
                    AppDomain domain = AppDomain.CreateDomain(setup.ApplicationName, AppDomain.CurrentDomain.Evidence, setup);
                    // Start application by executing the assembly.
                    int exitCode = domain.ExecuteAssembly(setup.ApplicationName);
                    reload = !(exitCode == 0);
                    AppDomain.Unload(domain);
                }
                return 2;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mainForm = new MainForm();
                Application.Run(mainForm);
                return mainForm.ExitCode;
            }
        }
    }
