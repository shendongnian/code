    using Code first approach .
    How to define primary key in Web API.
    
    Eg:- Model Class
      public class Categories
        {
            [Key]
            public int cateId { get; set; }
            public string cateName { get; set; }
        }
    Controller Class:-  Categories Controller
     public bool AddCate(Categories preg)
            {            
                db.Categories.Add(preg);
                db.SaveChanges();
                return true;
            }
    Context Db Class
      public System.Data.Entity.DbSet<TestingWebApi.Models.Categories> Categories { get; set; }
     Error:-"System.Data.Entity.Infrastructure.DbUpdateException",
