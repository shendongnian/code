    public string PartyID(Stream ABC)//json that i posted
        {   
            DataTable dt = new DataTable();
            string response = string.Empty;
            try
            {
                string Json = string.Empty;
                StreamReader sr = new StreamReader(ABC);
                dynamic param = JsonConvert.DeserializeObject<dynamic>(sr.ReadToEnd());
                string CommonCategoryAttributeName= param.CommonCategoryAttributeName;
                string CommonCategoryRowId= param.CommonCategoryRowId;
            
                string[] commonCategoryAttributeName= CommonCategoryAttributeName.Split(new char[] { ',' });
              
                DataTable tbl = new DataTable();
                tbl.Columns.Add("CommonCategoryAttributeName", typeof(string));
                tbl.Columns.Add("CommonCategoryRowId", typeof(long));
              
                for (int i = 0; i < CommonCategoryAttributesRowId.Length; i++)
                {
                    tbl.Rows.Add(CommonCategoryAttributeName[i], commonCategoryRowId);
                }
                string json = JsonConvert.SerializeObject(tbl, Formatting.None);
                json = Regex.Unescape(json);
                dt = (DataTable)JsonConvert.DeserializeObject(json.Trim(new Char[] { ' ', '"', '.' }), typeof(DataTable));
                SqlParameter[] parameters = { new SqlParameter("@commonAttributes", dt) };
                int result = yourclass.ExecuteNonQuery(null, CommandType.StoredProcedure, "commonID", parameters);
            }
            catch (Exception Ex)
            {
              
            }
            return response;
        }
