    class MyObject
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Value { get; set; }
    }
    static class DataAccess
    {
        public static MyObject GetMyObject(int id, string conString)
        {
            var cmd = GetCommandById(id);
            cmd.Connection = new SqlConnection(conString);
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var n = Convert.ToString(reader["Name"]);
                    var v = Convert.ToInt32(reader["Value"]);
                    return new MyObject()
                    {
                        Name = n, 
                        ID = id, 
                        Value = v
                    };
                }
            }
            return null;
        }
        static SqlCommand GetCommandById(int id)
        {
            var q = @"
                SELECT * FROM TABLE.MYOBJECT obj WHERE obj.ID = @id";
            var cmd = new SqlCommand(q);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            return cmd;
        }
    }
