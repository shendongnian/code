    public class CategoryController()
    {
        public ActionResult Index()
        {
            var model = new CategoryModel();
            model.CategoriesList = new List<SelectListItem>{...};
            return View(model);
        }
    
        public ActionResult SaveCategory(CategoryModel model)
        {
            model.SelectedCategoryId
            ...
        }
    }
