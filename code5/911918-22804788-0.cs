    // create a sample dictionary and fill it
    Dictionary<string, string> myCol = new Dictionary<string, string>();
    myCol.Add("server1", "ip1");
    myCol.Add("server2", "ip2");
    
    // grab a reference to the active Sheet
    // this may vary depending on what framework you are using
    Worksheet ws = Globals.ThisWorkbook.ActiveSheet as Worksheet;
    
    // create a Range variable
    Range myRange;
    
    // Transpose the keys to column A
    myRange = ws.get_Range("A1");
    myRange.get_Resize(myCol.Keys.ToArray().Count(),1).Value = 
                     ws.Parent.Parent.Transpose(myCol.Keys.AsEnumerable().ToArray());
    
    // transpose the Values to column B
    myRange = ws.get_Range("B1");
    myRange.get_Resize(myCol.Values.ToArray().Count(), 1).Value = 
                   ws.Parent.Parent.Transpose(myCol.Values.AsEnumerable().ToArray());
