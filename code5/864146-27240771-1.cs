    using (TfsTeamProjectCollection collection = new TfsTeamProjectCollection(TfsTeamProjectCollection.GetFullyQualifiedUriForName("<YourTFSServerURL>")))
    {
        ITestManagementService tcmService = collection.GetService<ITestManagementService>();
        ITestManagementTeamProject project = tcmService.GetTeamProject("<YourTFSProject>");
			
        //Get configuration, which contains configuration values
        ITestConfiguration testConfiguration = project.TestConfigurations.Query("Select * from TestConfiguration WHERE Name='" + yourConfigurationName + "'")[0];
        IDictionary<string, string> testConfigValues = testConfiguration.Values;
        string browser = testConfigValues["Browser"];
        string operatingSystem = testConfigValues["Operating System"];
    }
