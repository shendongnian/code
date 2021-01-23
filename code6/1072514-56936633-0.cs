    public void InsertArea(string nameParameter, string extentsString)
    {
           SqlConnection sqlConn = new SqlConnection(...)
    
           sqlConn.Open();
    
           SqlCommand sqlCom = new SqlCommand("INSERT INTO areas (name, extents) VALUES (@name, @extents)", sqlConn);
    
           sqlCom.Parameters.AddWithValue("@name", nameParameter);
    
           SqlParamater extents = new SqlParameter("@extents", SqlDbType.Udt);
           extents.UdtTypeName = "Geography";
           extents.Value = GetGeographyFromText(extentsString);
    
           sqlCom.Parameters.Add(extents);
    
           sqlCom.ExecuteNonQuery();
    
           sqlConn.Close();
    }
    
    public SqlGeography GetGeographyFromText(String pText)
    {
           SqlString ss = new SqlString(pText);
           SqlChars sc = new SqlChars(ss);
           try
           {
               return SqlGeography.STPolyFromText(sc, 4326);
           }
           catch (Exception ex)
           {
               throw ex;
           }
    }
     string areaName = "Texas";
           string extents = string.Format("POLYGON(({0} {1}, {0} {2}, {3} {2}, {3} {1}, {0} {1}))", leftLongitude, upperLatitude, lowerLatitude, rightLongitude));
    
           InsertArea(areaName, extents);
