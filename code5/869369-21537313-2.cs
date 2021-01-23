    var list1 = new List<string>();
    var list2 = new List<string>();
    var list3 = new List<string>();
    
    using(SqlDataReader rdr = cmd.ExecuteReader()) {
    
        while( rdr.Read() ) {
    
            list1.Add(rdr.GetString(0));
            list1.Add(rdr.GetString(1));
            list1.Add(rdr.GetString(2));
        }
    }
    
    //iterate through saved lists
    for(int i=0; i<list1.Count; i++)
    {
        var c1 = list1[i];
        var c2 = list2[i];
        var c3 = list3[i];
        Console.WriteLine(c1 + " " + c2 + " " + c3);
    }
