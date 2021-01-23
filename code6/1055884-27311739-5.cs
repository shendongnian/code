    using(OleDbConnection con = new OleDbConnection(conString))
    using(OleDbCommand VCOM = con.CreateCommand())
    {
        string VSQL = "INSERT INTO STUDENT VALUES (?, ?, ?, ?)";
        VCOM.CommandText = VSQL;
        VCOM.Parameters.Add("@p1").Value = int.Parse(TEXTBOX1.Text);
        VCOM.Parameters.Add("@p2").Value = TEXTBOX2.Text;
        VCOM.Parameters.Add("@p3").Value = TEXTBOX3.Text;
        VCOM.Parameters.Add("@p4").Value = int.Parse(TEXTBOX4.Text);
        con.Open();
        VCOM.ExecuteNonQuery();
        MessageBox.Show("DATA INSERTED");   
    }
