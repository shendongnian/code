    StringBuilder sb = new StringBuilder();
    while(SOME CONDITION)
    {
        sb.AppendLine("YOUR STRING"); 
    }
    // Set boolean to true to append to the existing file.
    using (StreamWriter outfile = new StreamWriter(mydocpath + @"\AllTxtFiles.txt", true))
    {
        outfile.WriteLine(sb.ToString());
    }
   
    //Append new text to an existing file. 
    // The using statement automatically closes the stream and calls  
    // IDisposable.Dispose on the stream object. 
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines.txt", true))
    {
        file.WriteLine("Your line");
    }
