     var csvFileBuffer = new StringBuilder();
     var columns = new List<string>();
     csvFileBuffer.AppendLine(
         string.Join(
             ",",
             columns.Select(s => 
                  //truncate column header (change logic as appropriate)
                  s.Substring(0, 255))));
