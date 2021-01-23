    using (StreamReader srReader = new StreamReader(strInputFile))
    {
        using (StreamWriter sw = new StreamWriter(strFullOutputPathFileName, false))
        {
            while ((strCurrentLine = srReader.ReadLine()) != null)
            {
                sw.WriteLine("stuff...");
            }
        }
    }
