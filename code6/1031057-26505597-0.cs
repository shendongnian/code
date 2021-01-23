    public class KeywordHandler : IHttpHandler
    {
        class Keyword
        {
            public string value { get; set; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["term"];
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DSN"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct Keyword from [dbo].[Log] where " + "Keyword like @SearchText + '%' and ResultCount != 0";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    List<Keyword> suggestedList = new List<Keyword>();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            suggestedList.Add(new Keyword { value = sdr["Keyword"].ToString() });
                        }
                    }
                    conn.Close();
                    suggestedList.OrderBy(x => x.value).ToList();
                    context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(suggestedList.Take(10)));
                }
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
