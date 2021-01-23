    SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial 
    Catalog=jadid;Integrated Security=True"); 
     
    SqlCommand com_sel = new SqlCommand(); 
    
    DataSet ds = new DataSet();   
    SqlDataAdapter adap = new
    
    SqlDataAdapter(com_sel);  
     
    com_sel.CommandText = "select * from t2 where id=1";  //
     
    com_sel.CommandType = CommandType.StoredProcedure;
    com_sel.Connection = con; 
    com_sel.Parameters.Add("@p1",textBox1.Text);
    con.Open();
    ds.Clear();
    adap.Fill(ds); 
    com_sel.ExecuteNonQuery();  
    
    dataGridView1.DataSource = ds.Tables[0];
     
    int i; //this way you display the data in the textbox 
    //TextBox1 is your textbox name 
    //lessthen:- less than sign not write
      
    for(i=0;i lessthen ds.Tables[0].Rows.Count-1;i++) {
     
    TextBox1.Text=ds.Tables[0].Rows[i]["Column"].ToString(); 
    }
