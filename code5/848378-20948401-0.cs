    string saveInfoFolder = string.Format(@"C:/Users/{0}/Desktop/RepositoryResults", Environment.UserName);
    ...
    string saveRepositoryResults = saveInfoFolder + "/RepositoryResults.txt";
    ...
    
    string createText = lstFileContents.Text;
    System.IO.File.WriteAllText(saveRepositoryResults, createText);
