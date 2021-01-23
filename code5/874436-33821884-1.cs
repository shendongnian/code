    using (StringWriter strXML = new StringWriter())
    {
       dtBulkUpload.TableName = "BulkUpload";
       dtBulkUpload.WriteXml(strXML, XmlWriteMode.IgnoreSchema, false);
       xmlString = strXML.ToString();
    }                                     
   
    using (SqlCommand cmd = new SqlCommand("Stored PROC Name"))
    {
       cmd.Parameters.AddWithValue("@dtBulkUpload", bulkUploadData);
                            //SqlParameter returnParameter = cmd.Parameters.Add("@result", SqlDbType.NVarChar);
                            //returnParameter.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@result", SqlDbType.NVarChar,3000);
                            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
    
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            
                            con.Open();
                            cmd.ExecuteNonQuery();
                            query = (string)(cmd.Parameters["@result"].Value.ToString());
                            con.Close();
