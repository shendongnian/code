    public abstract class ViewBase<T> : UserControl, IView<T> where T: IViewModel
    {
        public T ViewModel
        {
            get
            {
                return this.viewModel;
            }
            protected set
            {
                this.viewModel = value;
                this.DataContext = this.viewModel;
            }
        }
        public ViewBase(IUnityContainer container)
        {
            this.ViewModel = container.Resolve<T>();
        }
    }
