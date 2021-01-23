    Database _dbFactory = Common.Database;
                    DataSet dset = new DataSet();
                    Object[] _dbObject = DataBaseHelper.CreateConnection();
                    dset = _dbFactory.ExecuteDataSet("Jwl_sp_SearchByProductCategoryById", new object[] { _Id });
                    DataBaseHelper.CloseConnection((SqlConnection)_dbObject[0]);
                    DataTable dt = new DataTable();
                    dt = dset.Tables[0];
                    var objectTobeConverted = new DataLogic.Database.Jwl_ByProductCategory();
                    ConvertDataRowToObject(objectTobeConverted, dt);
