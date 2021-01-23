     SqlConnection cnn = new SqlConnection(/*Database connection credentails*/);
     SqlDataAdapter da = new SqlDataAdapter("select columnName from table", con); 
     DataSet ds = new DataSet(); 
     da.Fill(ds); 
    
     List<string> keyValues= new List<string>();
     foreach(DataRow row in ds.Tables[0].Rows)
     {
       keyValues.Add(row["columnName"].ToString());
     }
     
