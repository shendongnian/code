        private DTE2 _mApplicationObject;
        public DTE2 ApplicationObject
        {
            get
            {
                if (_mApplicationObject != null) return _mApplicationObject;
                // Get an instance of the currently running Visual Studio IDE
                var dte = (DTE)GetService(typeof(DTE));
                _mApplicationObject = dte as DTE2;
                return _mApplicationObject;
            }
        }
    public void createProjectsFromTemplates()
    {
        try
        {
            // Create a solution with two projects in it, based on project 
            // templates.
            Solution2 soln = (Solution2)ApplicationObject.Solution;
            string csTemplatePath;
            
            string csPrjPath = "C:\\UserFiles\\user1\\addins\\MyCSProject"; 
            // Get the project template path for a C# console project.
            // Console Application is the template name that appears in 
            // the right pane. "CSharp" is the Language(vstemplate) as seen 
            // in the registry.
            csTemplatePath = soln.GetProjectTemplate("ConsoleApplication.zip", 
              "CSharp");
            System.Windows.Forms.MessageBox.Show("C# template path: " + 
              csTemplatePath);
                // Create a new C# console project using the template obtained 
            // above.
            soln.AddFromTemplate(csTemplatePath, csPrjPath, "New CSharp 
              Console Project", false);
             
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
        }
    }
