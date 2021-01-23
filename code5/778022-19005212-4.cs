    public void AddCountry(Country country)
        {
    // a sample code to access the values from Class instance passed in this method
        string connString = WebConfigurationManager.ConnectionStrings["MyConnections"].ConnectionString;
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Insert into Country(Name, Capital,Currency,ISOCode)  
                           values(@Name,@Capital,@Currency,@ISOCode)";
        cmd.Connection = con;
       // Add the insert parameters
        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 20));
       // specify the values for insert parameters
       // using the Country class passed as parameter to this method 
        cmd.Parameters["@Name"].Value = country.Name; // country.Public_Field_Name
        cmd.Parameters.Add(new SqlParameter("@Capital", SqlDbType.NVarChar, 20));
        cmd.Parameters["@Capital"].Value = country.Capital;
        cmd.Parameters.Add(new SqlParameter("@Currency", SqlDbType.NVarChar, 20));
        cmd.Parameters["@Currency"].Value = country.Currency;
        cmd.Parameters.Add(new SqlParameter("@ISOCode", SqlDbType.NVarChar, 20));
        cmd.Parameters["@ISOCode"].Value = country.ISOCode;
       
        con.Open();
        // execute the Insert Command
          cmd.ExecuteNonQuery();    
      }
