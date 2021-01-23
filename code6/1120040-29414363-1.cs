    [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HatlarJSON(String HatAdi)
        {
    
            Hatlar[] allRecords = null;
            string sql = "SELECT * FROM Table";
            SqlConnection con = new SqlConnection("Data Source="ip";Initial Catalog="";User Id="";Password="";Integrated Security=False");
            con.Open();
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<Hatlar>();
                    while (reader.Read())
                        list.Add(new Hatlar { HatId = reader.GetInt32(0), HatAdi = reader.GetString(1), LevhaAciklama = reader.GetString(2) });
                    allRecords = list.ToArray();
                }
            }
    
    Context.Response.Write( Newtonsoft.Json.JsonConvert.SerializeObject(allRecords));
          //this is what I'm using
        
    
    Context.Response.Write( JavaScriptSerializer().Serialize(allRecords)); //your code
    
    
        }
