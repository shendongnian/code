    public DataSet GetAllJobs(BussinessObj objBussiness)
                {
                    DataSet ds = new DataSet();
                    IDbCommand selectCommand = null;
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@Mode", "DisplayDataPaging");
                    param[1] = new SqlParameter("@PageIndex", objBussiness.PageIndex);
                    param[2] = new SqlParameter("@PageSize", objBussiness.PageSize);
                    ds = objDataAccess.ExecuteDataset(_spName, param);
                    objBussiness.RecordCount = ds.tables(0).rows.count;
                    return ds;
                }
