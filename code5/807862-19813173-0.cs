            public DataTable getMyTable()
            {           
                openLocalDatabaseConnection();
                //used for populating the DataGridView
                SqlCommand _com = new SqlCommand(string.Format("select * from tab.myTable where Country = 'Angola' "), _conn);
                _com.CommandTimeout = _command_timeout;
        
                DataSet _ds = new DataSet();
                SqlDataAdapter _adapt = new SqlDataAdapter();
                try
                {
                    _adapt.SelectCommand = _com;
                    int i = _adapt.Fill(_ds, "Asset_Transactions");
                    if (_ds.Tables.Count > 0)
                    {
                        return _ds.Tables[0];
                    }
                    else
                    {
                        return makeErrorTable("GetMyTable", "No Table Returned for myTable");
                    }
                }
                catch (Exception e)
                {
                    return makeErrorTable("GetMyTable", e.Message);
                }
            }
