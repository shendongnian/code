        private void Execute_Package()
        {
            string [] pkgLocations = new string[]{
            	@"C:\tfs\z Reports\BI Projects\Customer Service Data Warehouse\Customer Service Data Warehouse",
            	@"C:\tfs\z Reports\BI Projects\Customer Service Data Warehouse\SRS DataMart SSIS\SRSDimCategorizationLoad.dtsx"};
            Package pkg;
            Application app;
            DTSExecResult pkgResults;
            Variables vars;
            app = new Application();
            foreach(string currentFile in pkgLocations)
            {
                pkg = app.LoadPackage(currentFile, null);
                // Assumes this variable exists in all of the packages
                vars = pkg.Variables;
                vars["A_Variable"].Value = "Some value";
                pkgResults = pkg.Execute();
            }
        }
