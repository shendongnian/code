    protected void Button2_Click(object sender, EventArgs e)
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\ASPNetDB.mdb;Persist Security Info=True");
        {
            da.InsertCommand = new OleDbCommand("INSERT INTO UserProfile (Rented) VALUES (?) WHERE [UserName] = ?", conn);
            string dvdrent = DG_Latest.SelectedRow.Cells[1].Text;            
            OleDbParameter p1 = new OleDbParameter();
            OleDbParameter p2 = new OleDbParameter();
            da.InsertCommand.Parameters.Add(p1);
            da.InsertCommand.Parameters.Add(p2);
            p1.Value = dvdrent;
            p2.Value = "myusername"; //your username value here   
            var myquery = string.Format("UPDATE DVD SET Stock = Stock - 1 WHERE Title =  ");
            var row = DG_Latest.SelectedRow;
            var title = row.Cells[1].Text;
            myquery = string.Format(myquery + "'{0}'", title);
    
            conn.Open();
    
            using (OleDbCommand cmd = new OleDbCommand(myquery, conn))
                cmd.ExecuteNonQuery();
    
            da.InsertCommand.ExecuteNonQuery();
    
            conn.Close();
            conn.Dispose();
        }
    }
