     string content = reader.ReadToEnd();
        
        string[] lignes = contenu.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        
        for (int i = 1; i < lignes.Length; i++)
        {
            // REMOVE COMMAS
        
            string[] values = csv.Split(new[] {','});
        
            // do something
        }
        
        reader.Close();
