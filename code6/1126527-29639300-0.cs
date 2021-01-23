    using System.Data;
    using System.Text;
    public int GetMatches(DataTable table1, DataTable table2)
    {
        DataSet set = new DataSet();
        //wrap the tables in a DataSet.
        set.Tables.Add(table1);
        set.Tables.Add(table2);
        //Creates a ForeignKey like Join between two tables.
        //Table1 will be the parent. Table2 will be the child.
        DataRelation relation = new DataRelation("IdJoin", table1.Columns[0], table2.Columns[0], false);
        //Have the DataSet perform the join.
        set.Relations.Add(relation);
        int found = 0;
        //Loop through table1 without using LINQ.
        for(int i = 0; i < table1.Rows.Count; i++)
        {
            //If any rows in Table2 have the same Id as the current row in Table1
            if (table1.Rows[i].GetChildRows(relation).Length > 0)
            {
                //Add a counter
                found++;
                //For debugging, proof of match:
                //Get the id's that matched.
                string id1 = table1.Rows[i][0].ToString();
                string id2 = table1.Rows[i].GetChildRows(relation)[0][0].ToString();
            }
        }
        return found;
    }
