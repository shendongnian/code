    public class ViewProvider<TView, TModel> : IViewProvider<TView, TModel> 
        where TView : IView<TModel> {
        Dictionary<object, IView> views = new Dictionary<object, IView>();
        Container container;
        IModelProvider<TModel> modelProvider;
        public ViewFactory(Container container,
            IModelProvider<TModel> modelProvider) {
            this.container = container;
            this.modelProvider = modelProvider;
        }
        public TView GetViewByKey(object key) {
            IView view;
        
            if (!this.views.TryGetValue(key, out view)) {
                this.views[key] = view = this.CreateView(key);
            }
            
            return view;
        }
        
        private TView CreateView(object key) {
            TView view = this.container.GetInstance<TView>();
            view.ViewModel.Model = this.modelFactory.CreateModel(key);
            return view;
        }
    }
