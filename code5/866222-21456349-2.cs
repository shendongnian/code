    public IEnumerable<Product> FindCategories(IEnumerable<Category> categories,  string[] keywords)
    {	
    	foreach (var category in categories)
    	{
    		if(keywords.Any(p => category.Description.Contains(p)))
    		{
    			foreach (var product in category.Products)
    			{
    				yield return product;
    			}
    		}
    		
    		if(category.Subcategories != null)
    		{
    			foreach (var element in FindCategories(category.Subcategories, keywords))
    			{
    				yield return element;			
    			}
    		}
    	}
    }
