    public void createProjectsFromTemplates(DTE2 dte)
    {
        try
        {
            // Create a solution with two projects in it, based on project 
            // templates.
            Solution2 soln = (Solution2)dte.Solution;
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
