    class Cat
    {
         public Guid catId { get; set; }
         public string catName { get; set; }
         public IEnumerable<Movement> Movements { get; set; }
         public int MovementsCount { get { return Movements.Count(); } }
    }
    var Categories = category.Select(u => new Cat() 
    {
        u.catId, 
        u.catName,     
        Movements = u.Movements.AsEnumerable()
    }).ToList();
    var CategoriesByCount = Categories.OrderBy(u => u.MovementsCount).ToList();
    
