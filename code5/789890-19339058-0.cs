    foreach (string sqlFile in files)
    { 
         Process sqlServer= new Process();
         sqlServer.StartInfo.FileName = sqlFile;
         sqlServer.Start();                                                    
    }
