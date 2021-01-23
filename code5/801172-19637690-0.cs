    StringBuilder builder = new StringBuilder(); 
    builder.AppendLine("HEADER STRING"); 
    
    var OutputText = listData.Select( x => x.Name, blah, blah, blah) ); 
    builder.Append(OutputText);
    
    string FilePath = @"C:\data.txt";
    System.IO.File.WriteAllLines(FilePath, builder.ToString());
