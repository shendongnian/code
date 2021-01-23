    var query =
    			from p in listProducts
    			join cl in listColor on p.ColorId equals cl.ColorId
    			join c in listCategories on p.CategoryId equals c.Id into e
    			from j in e.DefaultIfEmpty()group p by new
    			{
    			j.Id,cl.ColorId,j.CateName,cl.ColorName
    			}
    
    				into g
    				select new GroupModel
    				{
    				Products = g.ToList(), CategoryId = g.Key.Id, CateogryName = g.Key.CateName,ColorId = g.Key.ColorId,ColorName = g.Key.ColorName
    				}
    
    		;
    		foreach (var item in query)
    		{
    			Console.WriteLine("CategoryName: {0}", item.CateogryName);
    			//Console.WriteLine("ColorName: {0}", );
    			foreach(var product in item.Products)
    			{
    				Console.WriteLine("Product: |_ {0} - {1}", product.ProdName,item.ColorName);
    			}
    		}
