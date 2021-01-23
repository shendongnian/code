    public static void UpdatePrice(this IProduct pro, ref SystemContext sc)
    {
    	var relations = sc.Relations.Where(t => t.SubProduct.ID == pro.ID).ToList();
    	
    	for (int i = 0; i < relations.Count; i++)
    	{
            // calculate price 
            // add more relations to the list		
    	}    
    }
