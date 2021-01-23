        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> CategoryName(string prefixText, string contextKey)
        {
            //Your Stored Procedure HERE then,
     Your Sql Query where Condition should be 
                where Category Like '%' + @Category  + '%'
           
    
           //Return to get List you search
            List<string> Category= new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Category.Add(dt.Rows[i]["Category"].ToString());
            }
            return Category;
        }
