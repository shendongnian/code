     if (String.IsNullOrWhiteSpace(Qty) || Qty.Trim().Equals("0"))
        {
            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CIMProRPT01ConnectionString"].ConnectionString);
    
            con2.Open();
    
            string DeleteWMMRSQL = "DELETE FROM [CIMProRPT01].[dbo].[OTH_INV_QTY_LOC] WHERE INV_ID = @INV_ID AND INV_LOCATION = @INV_LOCATION";
    
            SqlCommand cmddelete = new SqlCommand(DeleteWMMRSQL, con2);
            cmddelete.Parameters.AddWithValue("@INV_ID",Inv_ID);
            cmddelete.Parameters.AddWithValue("@INV_LOCATION",FromLoc);
            cmddelete.ExecuteNonQuery();
    
            con2.Close();
    
        }
