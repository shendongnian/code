    public static void UpdatePrice(this IProduct pro, ref SystemContext sc)
    {
    	var realations = sc.Relations.Where(t => t.SubProduct.ID == pro.ID).ToList();
    	
    	for (int i = 0; i < relations.Count; i++)
    	{
            // calucalte price 
            // add more relations to the list		
    	}    
    }
