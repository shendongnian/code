    string sql2 = @"select Due.Loanno,Due.PName,Due.Duedate,sum(Due.Rec) as rec,sum(Due.Loanamt) as amt from Due  inner join Party_Det on Due.Loanno=Party_Det.Loanno where Due.Duedate between [@date1] and [@date2] group by Due.Loanno,Due.PName,Due.Duedate";
    OleDbCommand cmd2 = new OleDbCommand(sql2, con);
                 
    cmd2.Parameters.AddWithValue("@date1", dueDateBegin);
    cmd2.Parameters.AddWithValue("@date2", dueDateEnd);
    
    cmd2.ExecuteNonQuery();
    DataTable dt=new DataTable();
    OleDbDataAdapter da = new OleDbDataAdapter(cmd2);
    
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    con.Close();    
