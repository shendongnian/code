    string[] contenutoStorico = rigaStorico.Select(x => x.Name).ToArray();
        
    IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("history.txt", FileMode.Create, FileAccess.Write, myIsolatedStorage)))
    {
        for (int i = 0; i < contenutoStorico.Length; i++)
        {
            writeFile.WriteLine(contenutoStorico[contenutoStorico.Length-i-1]);                    
        }
        writeFile.Close();
    }
