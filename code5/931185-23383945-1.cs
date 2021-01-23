    public class CategoryController : ControllerBase<ICategoryService>
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public HttpResponseMessage Update(CategoryViewModel model)
        {
            try
            {
                this.categoryService.Update(model.Category);
            }
            catch (ValidationException ex)
            {
                return WebApiValidationHelper.ToResponseCode(ex);
            }
        }
    }
