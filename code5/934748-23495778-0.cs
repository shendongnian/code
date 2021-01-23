    var grouped = dt.AsEnumerable().GroupBy(c => c["MealSubCatName"].ToString())
        .Select(g => new
        {
            category = g.FirstOrDefault()["MealSubCatName"].ToString(),
            items = g.Select(r => new { 
                title = r["itemName"].ToString(), 
                image = r["imageURL"].ToString() 
            })
        });
    lvFood.DataSource = grouped;
    lvFood.DataBind();
