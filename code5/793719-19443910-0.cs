    protected void Button2_Click(object sender, EventArgs e)
    {
        int i;
        if (ViewState["count"] != null)
            i = Convert.ToInt32(ViewState["count"].ToString());
        else
            i = 2; // assuming that it is your starting point as given in question
        string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\yogi\Documents\mydb.mdb";
        string cmdstr1 = "select count(*) from quant_level1";
        OleDbConnection con1 = new OleDbConnection(constr);
        OleDbCommand com1 = new OleDbCommand(cmdstr1, con1);
        con1.Open();
        int count = (int)com1.ExecuteScalar();
        if (i < count)
        {
            string cmdstr = "select * from quant_level1 where id = i";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand com = new OleDbCommand(cmdstr, con);
            con.Open();
            OleDbDataReader reader = com.ExecuteReader();
            reader.Read();
            label1.Text = String.Format("{0}", reader[1]);
            RadioButton1.Text = String.Format("{0}", reader[2]);
            RadioButton2.Text = String.Format("{0}", reader[3]);
            RadioButton3.Text = String.Format("{0}", reader[4]);
            RadioButton4.Text = String.Format("{0}", reader[5]);
            con.Close();
            i++;
            ViewState["count"] = i.ToString();
        }
        con1.Close();
    }
