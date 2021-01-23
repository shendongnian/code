    public class ViewProvider<TView, TModel> : IViewProvider<TView, TModel> 
        where TView : class, IView<TModel> {
        Dictionary<object, TView> views = new Dictionary<object, TView>();
        Container container;
        IModelProvider<TModel> modelProvider;
        public ViewProvider(Container container,
            IModelProvider<TModel> modelProvider) {
            this.container = container;
            this.modelProvider = modelProvider;
        }
        public TView GetViewByKey(object key) {
            TView view;
        
            if (!this.views.TryGetValue(key, out view)) {
                this.views[key] = view = this.CreateView(key);
            }
            
            return view;
        }
        
        private TView CreateView(object key) {
            TView view = this.container.GetInstance<TView>();
            view.ViewModel.Model = this.modelProvider.GetModelByKey(key);
            return view;
        }
    }
