    int numProcessed = 0;
    foreach (string filepath in allXmlFiles)
    {
        try
        {
            ParseFile(filepath);
            numProcessed++; // or you could use '++numProcessed' inline
            if(numProcessed % 10 == 0 && numProcessed >= 10)
                UpdatedText("Another 10 files processed!");
        }
        catch
        {
            UpdateText(String.Format("\nCannot process file {0}", filepath));
        }
    }
    UpdatedText("Finished");
