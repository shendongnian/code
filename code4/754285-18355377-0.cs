    List<System.IO.StreamReader> files = new List<System.IO.StreamReader>
                         {
                                new System.IO.StreamReader("c:\\file1.txt"),
                                new System.IO.StreamReader("c:\\file2.txt"),
                                new System.IO.StreamReader("c:\\file3.txt")
                         };
    int lineCount = 0;
    bool hasMore = true;
    while(hasMore)
    {
       foreach(var file in files)
       {
           string fileLine = file.ReadLine();
           hasMore = fileLine != null;
           //add your processing here...
       }
       
       lineCount++;
       
    }
    
    file.Close();
