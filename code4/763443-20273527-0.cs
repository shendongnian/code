    static void Main(string[] args)
    {
        // 1. Create new package, and add a script task
        var pkg = new Package();
        var exec = pkg.Executables.Add("STOCK:ScriptTask");
        var th = (TaskHost)exec;
        th.Name = "Script Task";
        th.Description = "This is a Script Task";
        var task = (ScriptTask)th.InnerObject;
    
        // 2. Set the script language - "CSharp" or "VisualBasic"
        task.ScriptLanguage = VSTAScriptLanguages.GetDisplayName("CSharp");
        
        // 3. Set any variables used by the script
        //task.ReadWriteVariables = "User::Var1, User::Var2";
    
        // 4. Create a new project from the template located in the default path
        task.ScriptingEngine.VstaHelper.LoadNewProject(task.ProjectTemplatePath, null, "MyScriptProject");
    
        // 5. Initialize the designer project, add a new code file, and build
        //task.ScriptingEngine.VstaHelper.Initalize("", true);
        //task.ScriptingEngine.VstaHelper.AddFileToProject("XX.cs", "FileContents");
        //task.ScriptingEngine.VstaHelper.Build("");
    
        // 6. Persist the VSTA project + binary to the task
        if (!task.ScriptingEngine.SaveProjectToStorage())
        {
            throw new Exception("Save failed");
        }
    
        // 7. Use the following code to replace the ScriptMain contents
        var contents = File.ReadAllText("path to file");
        var scriptFile =
            task.ScriptStorage.ScriptFiles["ScriptMain.cs"] =
            new VSTAScriptProjectStorage.VSTAScriptFile(VSTAScriptProjectStorage.Encoding.UTF8, contents);
    
    
        // 8. Reload the script project, build and save
        task.ScriptingEngine.LoadProjectFromStorage();
        task.ScriptingEngine.VstaHelper.Build("");
    
        // 9. Persist the VSTA project + binary to the task
        if (!task.ScriptingEngine.SaveProjectToStorage())
        {
            throw new Exception("Save failed");
        }
    
        // 10. Cleanup
        task.ScriptingEngine.DisposeVstaHelper();
    
        // 11. Save
        string xml;
        pkg.SaveToXML(out xml, null);
    
        File.WriteAllText(@"c:\temp\package.dtsx", xml);
    }
