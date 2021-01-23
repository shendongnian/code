    ValidationReporter validationReporter = BidsHelper.CompileBiml(
        typeof(AstNode).Assembly, 
        "Varigence.Hadron.BidsHelperPhaseWorkflows.xml", 
        "Compile", bimlScriptPaths, 
        new List<string>(), 
        tempTargetDirectory, 
        projectDirectory, 
        SqlServerVersion.SqlServer2008, 
        SsisVersion.Ssis2012, 
        SsasVersion.Ssas2008, 
        DeployPackagesPlugin.IsLegacyDeploymentMode(project) ? 
            SsisDeploymentModel.Package : 
            SsisDeploymentModel.Project);
