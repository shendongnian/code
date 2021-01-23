    string delimiter = "##";
    
    string Path = yourCSVFilePathToSave;
    
    bool append = true;
    
    string HexadecimalFormat = "X";
    
    Encoding enc = Encoding.UTF-8;
    
    int bufferSize = 4096;
    
    int[] intArray = {1,2,3,4,5,6,7,8,9};
    
      using ( var writer = new StreamWriter(Path, append, enc, bufferSize))
      {
         foreach ( int i in intArray)
         {
           writer.Write (HexadecimalFormat, i);
           writer.Write (HexadecimalFormat, delimiter);
         }
       }
