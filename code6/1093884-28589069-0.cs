    ...
    DacServices dacSvc = new DacServices(connectionString);
    string deployScript = dacSvc.GenerateDeployScript(myDacpac, @"aDb", deployOptions);
    
    if (DatabaseEqualsDacPackage(deployScript))
    {
      Console.WriteLine("The database and the DacPackage are equal");
    }
    ...
    bool DatabaseEqualsDacPackage(string deployScript)
    {
      string equalStr = string.Format("GO{0}USE [$(DatabaseName)];{0}{0}{0}GO{0}PRINT N'Update complete.'{0}GO", Environment.NewLine);
      return deployScript.Contains(equalStr);
    }
    ...
