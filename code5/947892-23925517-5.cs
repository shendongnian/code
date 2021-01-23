    public AudAuditReportMaster UploadAuditReportDoc(string fileName, FileStream fs, string modifyBy, string processName)
           {
                
               AudAuditReportMaster objAudAuditReportMaster = new AudAuditReportMaster();
                
                BinaryReader brFileStream = new BinaryReader(fs);
                
                OpenConnection();
    
                int streamLength = (int)fs.Length;
                OracleTransaction transaction = objConn.BeginTransaction();
                objCmd.Transaction = transaction;
                objCmd.CommandText = "declare xx blob; begin dbms_lob.createtemporary(xx, false, 0); :tempblob := xx; end;";
                objCmd.Parameters.Add(new OracleParameter("tempblob", OracleType.Blob)).Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();
                OracleLob tempLob = (OracleLob)objCmd.Parameters[0].Value;
    
                byte[] tempbuff = new byte[streamLength];
                tempLob.BeginBatch(OracleLobOpenMode.ReadWrite);
                tempLob.Write(brFileStream.ReadBytes(streamLength), 0, streamLength);
                tempLob.EndBatch();
                objCmd.Parameters.Clear();
    
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = AudDB_Constants.Aud_Audit_Pkg.SP_Aud_Upload_Doc;
                objCmd.Parameters.Clear();
    
                OracleParameter param1 = objCmd.Parameters.Add("p_doc_name", OracleType.VarChar);
                param1.Value = fileName;
    
                objCmd.Parameters.Add(new OracleParameter("p_process_name", OracleType.VarChar)).Value = processName;
    
                objCmd.Parameters.Add(new OracleParameter("p_process_key_name", OracleType.VarChar)).Value = DBNull.Value;
                objCmd.Parameters.Add(new OracleParameter("p_process_key_id", OracleType.Int32)).Value = DBNull.Value;
    
                OracleParameter param2 = objCmd.Parameters.Add("p_document", OracleType.Blob);
                param2.Value = tempLob;
    
                OracleParameter param3 = objCmd.Parameters.Add("p_last_updated_by", OracleType.VarChar);
                param3.Value = modifyBy;
    
                objCmd.Parameters.Add(new OracleParameter("p_attribute1", OracleType.VarChar)).Value = DBNull.Value;
                objCmd.Parameters.Add(new OracleParameter("p_attribute2", OracleType.VarChar)).Value = DBNull.Value;
                objCmd.Parameters.Add(new OracleParameter("p_attribute3", OracleType.VarChar)).Value = DBNull.Value;
                objCmd.Parameters.Add(new OracleParameter("p_attribute4", OracleType.VarChar)).Value = DBNull.Value;
                objCmd.Parameters.Add(new OracleParameter("p_attribute5", OracleType.VarChar)).Value = DBNull.Value;
    
                OracleParameter param4 = objCmd.Parameters.Add("p_doc_id", OracleType.Int32);
                param4.Direction = ParameterDirection.Output;
    
                OracleParameter param5 = objCmd.Parameters.Add("p_status", OracleType.VarChar, 100);
                param5.Direction = ParameterDirection.Output;
    
                OracleParameter param6 = objCmd.Parameters.Add("p_status_dtl", OracleType.VarChar, 1000);
                param6.Direction = ParameterDirection.Output;
    
                objAudAuditReportMaster.Status = Convert.ToString(objCmd.ExecuteNonQuery());
                objAudAuditReportMaster.DocID = Convert.ToInt32(param4.Value.ToString());
                objAudAuditReportMaster.Status = param5.Value.ToString();
                objAudAuditReportMaster.StatusDetail = param6.Value.ToString();
                transaction.Commit();
                CloseConnection();
                DisposeConnection();
    
                return objAudAuditReportMaster;
            }
