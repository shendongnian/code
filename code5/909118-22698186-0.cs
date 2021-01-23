    using (StreamReader srReader = new StreamReader(strInputFile))
    {
        // write the "processed" strCurrentLine to a new text file
        using (StreamWriter sw = new StreamWriter(strFullOutputPathFileName, false))
        {
            // loop until EOF
            while ((strCurrentLine = srReader.ReadLine()) != null)
            {
                // "process" strCurrentLine...
    
                // write strCurrentLine to the new file
                sw.WriteLine("stuff...");
            }
         }
    }
