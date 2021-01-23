    public struct JQGridResults
        {
            public int page;
            public int total;
            public int records;
            public JQGridRow[] rows;
        }
    
    
    
    public struct JQGridRow
        {
           
            public string ItemCode;
            public string PartNumber;
            public string ItemDescriptionShort;
            public string ItemDescriptionLong;
            public string ProductCode;
            public string GroupCode;
            public string BusinessUnit;
            public string[] cell;
        }
        [Serializable]
       
    public class User
        {
            public string ItemCode { get; set; }
            public string PartNumber { get; set; }
            public string ItemDescriptionShort { get; set; }
            public string ItemDescriptionLong { get; set; }
            public string ProductCode { get; set; }
            public string GroupCode { get; set; }
            public string BusinessUnit { get; set; }
        }
    
        public class ItemCode : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                HttpRequest request = context.Request;
                HttpResponse response = context.Response;
    
                string _search = request["_search"];
                string numberOfRows = request["rows"];
                string pageIndex = request["page"];
                string sortColumnName = request["sidx"];
                string sortOrderBy = request["sord"];
    
    
                int totalRecords;
                Collection <User> users = GetUsers(numberOfRows, pageIndex, sortColumnName,sortOrderBy, out totalRecords);
                string output = BuildJQGridResults(users, Convert.ToInt32(numberOfRows),Convert.ToInt32(pageIndex), Convert.ToInt32(totalRecords));
                response.Write(output);
            }
            private string BuildJQGridResults(Collection <User> users, int numberOfRows, int pageIndex, int totalRecords)
            {
    
                JQGridResults result = new JQGridResults();
                List<JQGridRow> rows = new List<JQGridRow>();
                foreach (User user in users)
                {
                    JQGridRow row = new JQGridRow();
                    row.ItemCode = user.ItemCode;
                    row.PartNumber = user.PartNumber;
                    row.ItemDescriptionShort = user.ItemDescriptionShort;
                    row.ItemDescriptionLong = user.ItemDescriptionLong;
                    row.ProductCode = user.ProductCode;
                    row.GroupCode = user.GroupCode;
                    row.BusinessUnit = user.BusinessUnit;
                    
                    rows.Add(row);
                }
                result.rows = rows.ToArray();
                result.page = pageIndex;
                result.total = (totalRecords + numberOfRows - 1) / 8;
                result.records = totalRecords;
                JavaScriptSerializer serializer = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
                //return new JavaScriptSerializer().Serialize(result);
                return serializer.Serialize(result);
            }
    
    
            private Collection<User> GetUsers(string numberOfRows, string pageIndex, string sortColumnName, string sortOrderBy, out int totalRecords)
            {
                Collection<User> users = new Collection<User>();
                MySqlConnection conn = Functions.GetConnection();
                string sql;
                sql = "SELECT *  FROM swans.tblsomain,tblligerstatus;";
    
    
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader data1 = cmd.ExecuteReader();
                
                string connectionString = "server=127.0.0.1;database=swans;uid=root;password=''";
    
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select ItemCode,PartNumber,ItemDescriptionShort,ItemDescriptionLong,ProductCode,GroupCode,BusinessUnit from tblitemcodefromqne;";
                        command.CommandType = CommandType.Text;
    
                        MySqlParameter paramPageIndex = new MySqlParameter("@PageIndex",MySqlDbType.Int32);
                        paramPageIndex.Value = Convert.ToInt32(pageIndex);
                        command.Parameters.Add(paramPageIndex);
    
                        MySqlParameter paramColumnName = new MySqlParameter("@SortColumnName", MySqlDbType.VarChar, 50);
                        paramColumnName.Value = sortColumnName;
                        command.Parameters.Add(paramColumnName);
    
                        MySqlParameter paramSortorderBy = new MySqlParameter("@SortOrderBy", MySqlDbType.VarChar, 4);
                        paramSortorderBy.Value = sortOrderBy;
                        command.Parameters.Add(paramSortorderBy);
    
                        MySqlParameter paramNumberOfRows = new MySqlParameter("@NumberOfRows", MySqlDbType.Int32);
                        paramNumberOfRows.Value = Convert.ToInt32(numberOfRows);
                        command.Parameters.Add(paramNumberOfRows);
    
                        MySqlParameter paramTotalRecords = new MySqlParameter("@TotalRecords",MySqlDbType.Int32);
                        totalRecords = 0;
                        paramTotalRecords.Value = totalRecords;
                        paramTotalRecords.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramTotalRecords);
    
    
                        connection.Open();
    
                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            User user;
                            while (dataReader.Read())
                            {
                                user = new User();
                                user.ItemCode = Convert.ToString(dataReader["ItemCode"]);
                                user.PartNumber = Convert.ToString(dataReader["PartNumber"]);
                                user.ItemDescriptionShort = Convert.ToString(dataReader["ItemDescriptionShort"]);
                                user.ItemDescriptionLong =Convert.ToString(dataReader["ItemDescriptionLong"]);
                                user.ProductCode = Convert.ToString(dataReader["ProductCode"]);
                                user.GroupCode = Convert.ToString(dataReader["GroupCode"]);
                                user.BusinessUnit = Convert.ToString(dataReader["BusinessUnit"]);
                                users.Add(user);
                            }
                        }
                        totalRecords = users.Count;
    
                    }
    
                    return users;
                }
    
            }
    
    
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
    
        }   
