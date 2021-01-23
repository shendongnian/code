    OleDbConnection con = new OleDbConnection(constr);
    con.Open();
    OleDbCommand Comm1 = new OleDbCommand("select top 1  customer_id from tb_customer ORDER BY customer_id desc", con);
    OleDbDataReader DR_customer = Comm1.ExecuteReader();
    if (DR_customer.Read())
       textBox1.Text = DR_customer.GetValue(0).ToString();
    
