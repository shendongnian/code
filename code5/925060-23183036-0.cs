    var rowList = new List<object>();       
    while (reader.Read())
            {
                var nes = new
                { 
    
                    ProductID = reader["ProductID"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CategoryName = reader["CategoryName"].ToString(),
                    UnitPrice = reader["UnitPrice"].ToString()
                };
                rowList.Add(nes);
    
            }
    var serializeMe = new {table_name = rowList }
    stroutput = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(serializeMe );
    Response.Write(stroutput);
