      // 
       varb = new List<object>();
     // Example 
       varb.Add(new[] { float.Parse(GridView1.Rows[1].Cells[2].Text )});
     // JSON  + Serializ
    public string Json()
            {  
                return (new JavaScriptSerializer()).Serialize(varb);
            }
    //  Jquery SIDE 
      var datasets = {
                "Products": {
                    label: "Products",
                    data: <%= getJson() %> 
                }
   
