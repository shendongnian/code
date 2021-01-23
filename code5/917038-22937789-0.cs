    class MyContext : DbContext {}
    
    // ...
    using (MyContext context = new MyContext())
    {
       var den = context.Den.Find(DenId);
       // Inner join Linq
       var foodList = from a in context.Animals
                      from b in a.FoodList
                      join c in d.FoodList on c.FoodId equals b.FoodId
                      select c;
    }
