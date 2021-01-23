        public void ChangeFramework()
        {
            //Add Reference to envdte (Assemblies\Extensions\envDTE)
            string SolutionFile = @"C:\MyProject\MyProject.sln";
            string ProjectName = "MyProject";
            //------------------------------------------------------------------------
            //Find the Program ID from the registry for VisualStudio.DTE
            //Look it up In Registry: Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Classes
            System.Type oType = System.Type.GetTypeFromProgID("VisualStudio.DTE", true);
            EnvDTE.DTE dte = (EnvDTE.DTE)Activator.CreateInstance(oType, true);
            //------------------------------------------------------------------------
            //Open your Solution
            dte.Solution.Open(SolutionFile);
            //------------------------------------------------------------------------
            //Now In your solution go through what is listed in dte.Solution.Projects and find the one that match what you want to change target for
            int iItemsCount = dte.Solution.Projects.Count;
            string sCurrent = "";
            for (int i = 1; i <= iItemsCount; i++)
            {
                sCurrent = dte.Solution.Projects.Item(i).Name;
                if (dte.Solution.Projects.Item(i).Name == ProjectName)
                {
                    //Once you find your project, Change the Framework
                    EnvDTE.Project oProject = dte.Solution.Projects.Item(i);
                    oProject.Properties.Item("TargetFrameworkMoniker").Value = ".NETFramework,Version = v4.6.2";
                }
            }
            //------------------------------------------------------------------------
            //Close your Solution
            dte.Solution.Close();
        }
