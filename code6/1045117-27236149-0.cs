    @{
       if(!string.IsNullOrEmpty(Request.QueryString["query"]))
       {
         int result= 0;
            if(Int32.TryParse(HttpContext.Current.Request.QueryString["query"].ToString(), out result))
           {
             umbraco.MacroEngines.DynamicNode node = new umbraco.MacroEngines.DynamicNode(result);
    
               <h1> @node.Name </h1>
         }
         else 
         {
             <h2>No query found</h2>
           }
     }
     
    }
