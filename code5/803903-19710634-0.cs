    try
        {
            connection.Open();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
               DataRow item = ds.Tables[0].Rows[0];
               byte[] item1 = (byte[])item["FileImage"];
               ds.Tables.Clear();
               numArray = item1;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return numArray;
    }
