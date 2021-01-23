    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Services.WebServiceBinding(ConformsTo = System.Web.Services.WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    [System.Web.Services.WebMethod]
    public class Demo : System.Web.Services.WebService
    {
        public class Block
        {
            public int ID { set; get; }
            public string Name { set; get; }
            public string Price { set; get; }
        }
        public List<Block> GetBlockList()
        {
            List<Block> result = new List<Block>();
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection conn = new SqlConnection("Sql Connection String Here"))
                {
                    string sql = "SELECT id, name, price FROM tableName WHERE block = @block";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception e)
                        {
                            string ex = e.ToString(); // Do something with the error
                        }
                        dt.Load(cmd.ExecuteReader());
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add(new Block(){
                        ID = int.Parse(dt.Rows[i].ItemArray.GetValue(0).ToString()),
                        Name = dt.Rows[i].ItemArray.GetValue(1).ToString(),
                        Price = dt.Rows[i].ItemArray.GetValue(2).ToString()
                    });
                }
            }
            return result;
        }
    }
