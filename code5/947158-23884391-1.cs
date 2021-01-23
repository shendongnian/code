    public void verifieEntete()
    {
        string absolutFilePath = boxFilePath.Text + '\\' + filename;
        if (!File.Exists(absolutFilePath) // <--- ADD EXPLICIT CHECK
        {
             // Create the file here. 
        }
        // Now we know the file is *sure* to exist, because we handled it 
        // explicitly.
        String[] fileContent = File.ReadAllText(absolutFilePath).Split(',');
        for (int i = 0; i < fileContent.Length; i++)
            if (fileContent[i].Contains("MAC;SERIAL;IP;MODELE;MODULE-EXT"))
                enteteExiste = true ;    
    }
