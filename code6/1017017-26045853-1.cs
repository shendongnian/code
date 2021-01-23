    public class ProductVM
    {
       public int Id { get; set; }
       public string Desc { get; set; }
       public string DetailDesc { get; set; }
       public List<CategoryVM> cats { get; set; }
    }
    public class CategoryVM
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Desc { get; set; }
        public string DetailDesc { get; set; }
    }
     ProductVM product = new ProductVM();
            
      using (YourEntities context = new YourEntities ())
      {                 
          product = (from x in context.Parents
                     where x.Id == 1
                     select new ProductVM
                     {
                         Id = x.Id,
                         Desc = x.Descr,
                         DetailDesc = x.DetailDesc
                      }).FirstOrDefault();
        product.Categegories = (from x in context.Children
                               where x.ParentId == product.Id
                              select new CategoryVM
                              {
                                 Id = x.Id,
                                 ParentId = (int)x.ParentId,
                                 Desc = x.Descr == null ? product.Desc : x.Descr,
                DetailDesc = x.DetailDesc == null ? product.DetailDesc : x.DetailDesc
                                }).ToList();
               }
