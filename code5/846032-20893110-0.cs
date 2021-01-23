    Type type = Type.GetTypeFromProgID("VisualStudio.DTE.11.0");
    Object obj = System.Activator.CreateInstance(type, true);
    EnvDTE80.DTE2 dte = (EnvDTE80.DTE2)obj;
    EnvDTE100.Solution4 _solution = (EnvDTE100.Solution4)dte.Solution;
    _solution.Create(@"C:\Test\", "Test");
    _solution.SaveAs(@"C:\Test\Test.sln");
