    public string GetJson(DataTable dt)
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new
    
                System.Web.Script.Serialization.JavaScriptSerializer();
                List<object[]> obj = new List<object[]>();
    
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(dr.ItemArray);
                }
                return serializer.Serialize(obj);
            }
