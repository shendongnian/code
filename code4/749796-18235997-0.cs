    private IEnumerable<SelectListItem> allCategories;
    public IEnumerable<SelectListItem> AllCategories
    {
        get
        {
            if (allCategories == null)
            {
                var _engine = new NopEngine();
                var categoryService = _engine.Resolve<ICategoryService>();
                allCategories = categoryService.GetAllCategories().Select(m =>
                    new SelectListItem { Value = m.Name, Text = m.Name })
            }
            return allCategories;
        }
        // You don't need a setter
    }
