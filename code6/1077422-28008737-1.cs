    public string GetDetails(object oItem)
        {
    		// use the oData to get your Data and formats them
            var oData = (ProductsItems)oItem;
    		
    		// use a String Builder to render inside of it
            StringBuilder sbRenderOnMe = new StringBuilder();
    
            // oData.subItems this must be a list of strings base on your code
            foreach (var Title in oData.subItems)
            {
                sbRenderOnMe.AppendFormat("Title:{0} <br>", Title);
            }
    
            // and here return the results
            return sbRenderOnMe.ToString();		
        }
		
