    queryString = "SELECT * FROM product WHERE prd_code = @c OR prd_name=@pn ";
    SqlCommand command = new SqlCommand(queryString, con);
    command.Parameters.AddWithValue("@c", Convert.ToInt32(txtpCode.Text));
    command.Parameters.AddWithValue("@pn", txtpName.Text.ToString());
    con.Open();
    
    using (SqlDataReader dr = command.ExecuteReader())
    {
        if (dr != null && dr.HasRows && dr.Read() == true)
        {
            if (txtpCode.Text == "")
            {
                txtpCode.Text = dr["prd_code"].ToString();
            }
            else if (txtpName.Text == "")
            {
               txtpName.Text = dr["prd_name"].ToString();
            }
            
            txtpCompany.Text = dr["prd_company"].ToString();
            UnitPrice.Text = dr["prd_price"].ToString();
            txtDiscount.Text = dr["prd_dis"].ToString();
            txtFinalRate.Text = dr["prd_final"].ToString();
        } 
        else
        {
            MessageBox.Show("No such record exists");
    
            if (txtpName.Text == "")
            {
                txtpCode.Text = "";
            }
            else if (txtpCode.Text == "")
            {
                 txtpName.Text = "";
            }
         }  
        dr.Close();   // <-------------------- Look here
        con.Close;    // <-------------------- and here
    } 
      
