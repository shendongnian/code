        *using ( DbCommand dbc = db.GetStoredProcCommand("[Personnel].[uspWebLogin]"))
                {
                    db.AddInParameter(dbc, "UserLogin", DbType.String, user.UserLogin);
                    db.AddInParameter(dbc, "UserPassword", DbType.String, user.Password);
                    DataSet ds = db.ExecuteDataSet(dbc);
                    DataTableReader dtr =  ds.CreateDataReader();
                    
    				// string count just to check theat the core query actualy worked when there is no exception
    				string count = dtr.FieldCount.ToString();
    				......
                    return new WebUser();
                }*
