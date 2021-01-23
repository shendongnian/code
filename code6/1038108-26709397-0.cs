    public int UploadFileToDB(string uFilePath, string uFilename, string uFileType, int uFileExpiryCapping, string uFilePhysicalPath)
            {
                int intResult = 0;
                try
                {
                    string strConnectionString = string.Empty;
                    FileStream fs = new FileStream(uFilePath, FileMode.OpenOrCreate, FileAccess.Read);
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, System.Convert.ToInt32(fs.Length));
                    DataSet ds = new DataSet("UploadedFiles");
                    // Set up parameters (7 input and 1 output) 
                    SqlParameter[] arParms = new SqlParameter[6];
    
                    //@UserName Input Parameter
                    arParms[0] = new SqlParameter("@UploadedFile", SqlDbType.Image);
                    arParms[0].Value = fileData;
                    arParms[0].Direction = ParameterDirection.Input;
    
                    //@FirstName Input Parameter
                    arParms[1] = new SqlParameter("@UploadedFileName", SqlDbType.NVarChar, 100);
                    arParms[1].Value = uFilename;
                    arParms[1].Direction = ParameterDirection.Input;
    
                    //@LastName Input Parameter
                    arParms[2] = new SqlParameter("@UploadedFileType", SqlDbType.NVarChar, 50);
                    arParms[2].Value = uFileType;
                    arParms[2].Direction = ParameterDirection.Input;
    
                    //@MiddleName Input Parameter
                    arParms[3] = new SqlParameter("@UploadedFileExpiryCapping", SqlDbType.Int);
                    arParms[3].Value = uFileExpiryCapping;
                    arParms[3].Direction = ParameterDirection.Input;
    
                    //@MobileNo Input Parameter
                    arParms[4] = new SqlParameter("@UploadedFileSaveLocation", SqlDbType.NVarChar, int.MaxValue);
                    arParms[4].Value = uFilePhysicalPath;
                    arParms[4].Direction = ParameterDirection.Input;
    
                  
    
    
                    //@DataInserted Output Parameter
                    arParms[5] = new SqlParameter("@ErrorCode", SqlDbType.Int);
                    arParms[5].Direction = ParameterDirection.Output;
    
    
                    strConnectionString = ""; // initialise connection string
                  
    
                    using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
                    {
                        intResult = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.StoredProcedure, "Your Procedure", arParms);
                    }
    
                    
                }
                catch (Exception ex)
                {
                   
                }
                finally
                {
                    fs.Dispose();
                }
                return intResult;
            }
