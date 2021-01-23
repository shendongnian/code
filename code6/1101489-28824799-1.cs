    public void AddCompanyDetails(int NDAid)
    {
        if (checkComRegnumberAvailable(oc.RegNumber))
        {
            using (SqlConnection con = new SqlConnection(cs))
            {             
                SqlCommand cmd = new SqlCommand("INSERT INTO OtherCompanyData (RegNumber,ComName,Country,Address,CoreBusi) values (@regnum,@comname,@country,@address,@corebusi) ", con);
                cmd.Parameters.AddWithValue("@regnum", oc.RegNumber);
                cmd.Parameters.AddWithValue("@comname", oc.ComName);
                cmd.Parameters.AddWithValue("@country", oc.Country);
                cmd.Parameters.AddWithValue("@address", oc.RegOfficeAddress);
                cmd.Parameters.AddWithValue("@corebusi", oc.CoreBuss);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
        AddNDADetails(NDAid);        
    }
