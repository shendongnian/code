    private void btn_Create_Click(object sender, EventArgs e)
          {
              try
              {
                  //// Get an instance of the currently running Visual Studio IDE.
                  System.Type type = System.Type.GetTypeFromProgID("VisualStudio.DTE.12.0");
                  Object obj = System.Activator.CreateInstance(type, true);
                  EnvDTE.DTE dte = (EnvDTE.DTE)obj;
                  dte.MainWindow.Visible = true; // optional if you want to See VS doing its thing
    
                  // create a new solution
                  dte.Solution.Create(@"C:\NewSolution\", "NewSolution");
                  var solution = dte.Solution;
    
                  // create a C# WinForms app
                  solution.AddFromTemplate(@"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\WindowsApplication\csWindowsApplication.vstemplate",
                      @"C:\NewSolution\WinFormsApp", "WinFormsApp");
    
                  // create a C# class library
                  solution.AddFromTemplate(@"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\ClassLibrary\csClassLibrary.vstemplate",
                      @"C:\NewSolution\ClassLibrary", "ClassLibrary");
    
                  // save and quit
                  dte.ExecuteCommand("File.SaveAll");
                  dte.Quit();
              }
              catch (Exception ex)
              {
                  throw;
              }
          }  
