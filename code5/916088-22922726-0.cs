    public ViewResult Index()
       {
           var items = _repo.GetAll().ToList();
           var categories = items.Select(c => new CategoryViewModel
           {
               Id = c.Id,
               Name = c.Name,
               Parent = c.Parent.HasValue ? c.Parent.Value : (Guid?) null,
               Products = c.Product.ToList(),
               ChildList = new List<CategoryViewModel>()
           }).OrderBy(o => o.Parent).ToList();
          var sortedCategories = categories.First();
          sortedCategories.ChildList = categories.Where(o => o.Parent != null && o.Parent == sortedCategories.Id).ToList();
         
          foreach (var l in categories.Where(l => l.Parent != null))
          {
              l.ChildList = categories.Where(o => o.Parent != null && o.Parent == l.Id).ToList();
          }
         
           return View(sortedCategories);
       }
