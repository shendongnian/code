        private void BuildAndReturnErrorDataSet()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CTSSQL"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "dbo.sp_reqdataerrorlog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_inTrans", SqlDbType.NChar, 12).Value = p_transaction;
            cmd.Parameters.Add("@vo_enclosure", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@vo_trans", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Connection.Close();
            enclosure = "" + cmd.Parameters["@vo_enclosure"].Value;
            extran = "" + cmd.Parameters["@vo_trans"].Value;
            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CTSSQL"].ConnectionString);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandText = "dbo.sp_errorlog";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@p_inTrans", SqlDbType.NChar, 12).Value = p_transaction;
            cmd2.Parameters.Add("@p_enclosure", SqlDbType.NChar, 6).Value = enclosure;
            cmd2.Parameters.Add("@p_trans", SqlDbType.NChar, 18).Value = extran;
            cmd2.Parameters.Add("@p_method", SqlDbType.NChar, 6).Value = "812";
            cmd2.Parameters.Add("@p_message", SqlDbType.NVarChar, 250).Value = "WEB Error: " + Ex.Message;
            cmd2.Parameters.Add("@vo_message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
            cmd2.Parameters.Add("@vo_errorDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();
            cmd2.Connection.Close();
            eDate = "" + cmd2.Parameters["@vo_errorDate"].Value;
            SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CTSSQL"].ConnectionString);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            cmd3.CommandText = "dbo.sp_selecterrorlog";
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("@p_trans", SqlDbType.NChar, 18).Value = p_transaction;
            cmd3.Parameters.Add("@p_date", SqlDbType.DateTime).Value = eDate;
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds, "ErrorLog");
            con3.Open();
            cmd3.ExecuteNonQuery();
            con3.Close();
            cmd3.Connection.Close();
            return ds;
        }
        if(!hasRows)
        {
            // Call error data set building logic
            BuildAndReturnErrorDataSet();
        }
        catch (Exception Ex)
        {
            // Call error data set building logic
            BuildAndReturnErrorDataSet();
        }
