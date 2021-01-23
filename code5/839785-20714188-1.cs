        private void button1_Click(object sender, EventArgs e)
        {
            String name = "Items";
            String filenamewithpath = @"C:\Users\itpr13266\Desktop\test.xls";
            String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filenamewithpath +
                                     ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
