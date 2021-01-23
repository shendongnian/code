    string[] oku = File.ReadAllLines("test.prp");
    foreach(string sLine in oku)
    {
        string[] columns = sLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        // Check for columns here.
        if (columns.Length >= 2)
        {
            string col2_and_3 = columns[1]+" "+colunms[2];
            // Do something with col2_and_3
       }
    }
      
