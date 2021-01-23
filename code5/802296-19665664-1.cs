    public DataSet1 Dataset_load(String query)
    {
        DataSet1 ds = new DataSet1();
        using(SqlConnection sqlcon = new SqlConnection(conStr))
        using(SqlCommand sqlCom = new SqlCommand("select * from Login", sqlcon))
        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom))
        {
            try
            {
                //sqlCom.ExecuteNonQuery();
                //sqlDA.Fill(ds,"Login");
                DataTable dt = new DataTable("DT_CR");
                sqlDA.Fill(dt);
                ds.Tables[0].Merge(dt);
                return ds;
            }
            catch (SqlException se)
            {
                Response.Write(se.Message);
                return null;
            }
            catch (Exception exc)
            {
                Response.Write(exc.Message);
                return null;
            }
        }
    }
