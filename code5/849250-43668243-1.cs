    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
        
    public static class Validation
    {
        public static List<dynamic> GetTable()
        {
            string _sql = "Select * from MyTable"
            List<dynamic> table = null;
    
            try
            {
                using (SqlConnection _conn = new SqlConnection(HelperData._conn_string))
                {
                    _conn.Open();
    
                    using (SqlCommand _cmd = new SqlCommand(_sql, _conn))
                    {
                        _cmd.CommandTimeout = 600;
    
                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            table = new List<dynamic>();
    
                            while (reader.Read())
                            {
                                var row = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;
    
                                for (int field = 0; field <= reader.FieldCount - 1; field++)
                                {
                                    row.Add(reader.GetName(field), reader[field]);
                                }
                                table.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return table;
        }
    }
