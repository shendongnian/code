       if (!RepositoryResults.Exists)
        {
            //update the text file with the details
            string createText = lstFileContents.Text;
            File.WriteAllText(saveRepositoryResults, createText);
        }
       else
       {
            string createText = lstFileContents.Text;
            File.WriteAllText(saveRepositoryResults, createText);
       }
