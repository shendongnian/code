    public void verifieEntete()
    {
        string absolutFilePath = boxFilePath.Text + '\\' + filename;
        if (File.Exists(absolutFilePath) // <--- ADD EXPLICIT CHECK
        {
            String[] fileContent = File.ReadAllText(absolutFilePath).Split(',');
            for (int i = 0; i < fileContent.Length; i++)
                if (fileContent[i].Contains("MAC;SERIAL;IP;MODELE;MODULE-EXT"))
                    enteteExiste = true ;    
        }
    }
