    int TotalLines(string filePath)
    {
      using (StreamReader r = new StreamReader(filePath))
        {
        int i = 0;
        while (r.ReadLine() != null) { i++; }
        return i;
        }
    }
    System.IO.StreamReader file = new System.IO.StreamReader(fileDirectory); //Open     StreamReader
    
    for (int q = 0; q <= TotalLines + 1; i++)
      {
         file.ReadLine();
             if(q == int + 1)
                 { do stuff... }
     }
