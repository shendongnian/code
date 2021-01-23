    try
    {
        string fileToDownload = MapPath(@"~\Sample.txt");
        string fileToRead = MapPath(@"~\FileNotExist.txt");
        try
        {
            //Section 1
            try
            { 
                // try to read the file which does not exist to raise the exception
                StreamReader ss = new StreamReader(fileToRead);
            }
            catch (IOException IoEx)
            {
                // Just for sample exception
            }
            // Section 2 code block still execute because exception handled by upper try catch block 
            //Section 2
            Response.Clear();
            Response.ClearHeaders();
