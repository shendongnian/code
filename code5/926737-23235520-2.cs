     protected DataTable getDataTablebyProcedure(string ProcedureName)
        {
        SqlDataAdapter da= new SqlDataAdapter();
        DataTable dt=new DataTable();
        try
            {//open a connection to your DB
            da.Fill(dt);
            }
        catch (Exception ex)
            {//handle Exception
            }
        finally
            {//Close Connection
            }
        return dt;
        }
