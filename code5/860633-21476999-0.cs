        InitialSessionState initalState = InitialSessionState.Create();
        initalState.ImportPSModule(new String[] { "msonline" });
        //initalState.LanguageMode = PSLanguageMode.FullLanguage;
        Office365Runspace = RunspaceFactory.CreateRunspace(initalState);
        Office365Runspace.Open();
