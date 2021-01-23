    DataColumn col;
                DataTable table1 = new DataTable();
                table1.PrimaryKey = new DataColumn[] { 
                      col = table1.Columns.Add("Id")
           };
                col.Unique = true;
                col = table1.Columns.Add("SrNo");
                col = table1.Columns.Add("Skill");
                col = table1.Columns.Add("Desc");
    
                table1.Rows.Add(1, "1.", "Social","--");
                table1.Rows.Add(2, "1.1", "Emotional", "--");
                table1.Rows.Add(3, "1.2", "Teaching ", "--");
                table1.Rows.Add(4, "2.1", "Values", "--");
                table1.Rows.Add(5, "2.2", "Attitude", "--");
    
    
                DataTable table2 = new DataTable();
                table2.PrimaryKey = new DataColumn[] { 
          col = table2.Columns.Add("Id") 
           };
                col.Unique = true;
                col = table2.Columns.Add("Grade");
                col = table2.Columns.Add("Remarks");
                table2.Rows.Add(1,"A","--");
                table2.Rows.Add(2,"B","--");
                table2.Rows.Add(3,"C","--");
    
                table1.Merge(table2);
