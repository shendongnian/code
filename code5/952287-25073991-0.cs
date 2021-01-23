    //Code to perform at the time of installing application
    public override void Install(System.Collections.IDictionary stateSaver)
    {
        if (Debugger.IsAttached == false) Debugger.Launch();
        CustomParameters cParams = new CustomParameters();
        cParams.Add("InstallPath", this.Context.Parameters["targetdir"]);
        cParams.SaveState(stateSaver);
        //Continue with install process
        base.Install(stateSaver);
    }
