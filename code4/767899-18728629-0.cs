    long position = 0;
    while position >= 0
    {
      position = ReadFiftyLines(argLogFile,0);
    }
    public long ReadFiftyLines(string argLogFile, long argPosition)
    {
       using(FileStream fs = new FileStream(argLogFile,FileMode.Open,FileAccess.Read))
       {
           string line = null;
           if (argPosition == 0)
           {
              line = reader.Readline();
              if (line == null)
              {
                 return -1; // empty file
              }
           }
           else
           { 
              fs.Seek(argPosition,SeekOrigin.Begin);
           }
           StreamReader reader = new StreamReader(fs);
           int count = 0;
           while ((line = reader.ReadLine() != null) && (count < 50))
           {
              count++;
              // do stuff with line
           }
           if (line == null)
           {
              return -1; // end of file
           }
           return fs.Position;
       }
    }
