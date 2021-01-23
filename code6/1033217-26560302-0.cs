    if (e.KeyCode == Keys.Enter)
    {
    e.Handled = true;
    e.SuppressKeyPress = true;
    string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=access.mdb";
         string strCommand = "SELECT PASSWORD FROM regulate where NAME=@ID";
            OleDbConnection conn = new OleDbConnection(strConnection);
            OleDbCommand com = new OleDbCommand(strCommand, conn);
            OleDbDataReader dr;
            com.Parameters.AddWithValue("@ID", txtName.Text);
    conn.Open();
            dr = com.ExecuteReader();
            if (dr.Read())
            { 
                txtVaries.Text = dr["PASSWORD"].ToString();
            }
            conn.Close();
                if (txtVaries.Text == txtPW.Text)
                {
                    tabControl1.TabPages.Remove(tabPW);
                    tabControl1.TabPages.Remove(tabMain);
                    tabControl1.TabPages.Insert(0, tabEdit);
                }
            }
