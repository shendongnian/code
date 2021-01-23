     if (txtSearch.Text != "")
        {                        
          SqlCommand com = new SqlCommand(query, oCn);
          com.CommandType = CommandType.StoredProcedure;
          com.Parameters.AddWithValue("@Variable", txtSearch.Text);  
          com.Parameters.AddWithValue("@CustomerId",Session["customerId"]);   
          com.Parameters.AddWithValue("@Status", txtStatus.Text);   
          SqlDataSource1.SelectCommand = com;
          GridView1.DataBind();
       }
