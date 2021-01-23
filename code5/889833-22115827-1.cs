    string cmdText = "Select * From [" + name + "$] WHERE secondColumnName = 'First'";
    using(OleDbConnection con = new OleDbConnection(constr))
    using(OleDbCommand oconn = new OleDbCommand(cmdText con))
    {
         con.Open();
         OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
         System.Data.DataTable data = new System.Data.DataTable();
         sda.Fill(data);
         dgvIM.DataSource = data;
    }
