    try
    {    
         string constring = "Data Source=(local);Initial Catalog=FAUMA;User ID=sa;Password=P@ssw0rd";
         string Query = @"update OnSiteWorkTx set Processed = 1 
                          where Company = @company and Processed = 0";
         using(SqlConnection conDatabase = new SqlConnection(constring))
         using(SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase))
         {
             cmdDatabase.Parameters.AddWithValue("@company", DropDownListPdf.Text);
             conDatabase.Open();
             cmdDatabase.ExecuteNonQuery();
         }
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }
