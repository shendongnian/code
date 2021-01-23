    SqlDataAdapter oks = new SqlDataAdapter("SELECT * FROM Project where Status = 'YES'", con);
    
    oks.fill(dataSet)
    
    if (dataSet.Tables["Table"].Rows.Count > 1)
     {
        label1.Text = "POSITIVE";
      }
       else
      {
        label1.Text = "NEGATIVE";
    
      }
