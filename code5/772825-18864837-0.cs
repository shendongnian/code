        @{
          var str="Shoes";
    }
    
    <form action="~/Home/Products_By_Category/@str" method="post">
    
          <input type="submit" value="Shoes" class="btn"/>
                           
    </form>
/////////////
    public ActionResult Products_By_Category(string s)
    {
           var context = new Shoe_StoreDBEntities();
           var q = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.Id
                where c.Name.Equals(s)
                select new { p, c };
    }
