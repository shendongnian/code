    protected void MonthLanguage( OdbcConnection conn )
    {
        var sql = " SET lc_time_names = 'de_DE'; "; 
            using (OdbcCommand command =
                new OdbcCommand(sql, conn ))
            {
                try
                {
                    command.Connection.Open(); 
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("operation failed!", ex);
                }
            }
    }
    public DataTable GridViewBind()
    {
        sql = " ... ";
        using( var cn = new OdbcConnection(
               ConfigurationManager.ConnectionStrings["cn"].ConnectionString) )
        {
            try
            {
                 MonthLanguage( cn ); // This sets the language for this connection
                 dadapter = new OdbcDataAdapter(sql, cn);
                 dset = new DataSet();
                 dset.Clear();
                 dadapter.Fill(dset);
                 DataTable dt = dset.Tables[0];
                 GridView1.DataSource = dt;
                 GridView1.DataBind();
                 return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dadapter.Dispose();
                dadapter = null;
                cn.Close();
            }
        }
    }
