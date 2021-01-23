    public static List<CommonPages> GetCommonPagesDescription(int Type)
    {
        List<CommonPages> CommonPageDescription = new List<CommonPages>();
        try
        {
            SqlCommand comGetAllFiles = new SqlCommand("GetCommonPageDescriptions", conDB);
            comGetAllFiles.CommandType = CommandType.StoredProcedure;
            if (conDB.State != ConnectionState.Open)
                conDB.Open(); // <-- Debugger Skip this & goto next line
            comGetAllFiles.Parameters.Add("@Type", SqlDbType.Int);
            comGetAllFiles.Parameters["@Type"].Value = Type;
    
            SqlDataReader rdr = comGetAllFiles.ExecuteReader();//<-- error generating here
            DataTable dt = new DataTable();
            dt.Load(rdr);
            foreach (DataRow r in dt.Rows)
            {
                CommonPageDescription.Add(new CommonPages
                {
                    Id = (int)r["Id"],
                    Description = r["Description"].ToString(),
                    Type = (int)r["Type"],
                    UpdatedDate = (DateTime)r["UpdatedDate"],
                    UpdatedBy = (Guid)r["UpdatedBy"]
    
                });
            }
    
        }
        catch (Exception ee)
        {
        }
        finally
        {
            conDB.Close();
        }
        return CommonPageDescription;
    }
