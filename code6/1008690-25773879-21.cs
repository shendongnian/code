    public class FillPropertiesController : Controller
    {
        IViewProvider<FillPropertiesView, FillPropertiesModel> viewProvider;
        FillPropertiesView view;
        public FillPropertiesController(
            IViewProvider<FillPropertiesView, FillPropertiesModel> provider) {
            this.viewProvider = provider;
        }
        public void Reinitialize(object key) {
            this.view = this.viewProvider.GetViewByKey(key);
        }
    }
