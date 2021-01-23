    class ViewManager
    {
        void ShowView<T>(ViewModelBase viewModel)
            where T : ViewBase, new()
        {
            T view = new T();
            view.DataContext = viewModel;
            view.Show(); // or something similar
        }
    }
    abstract class ViewModelBase
    {
        public void ShowView(string viewName, object viewModel)
        {
            MessageBus.Post(
                new Message 
                {
                    Action = "ShowView",
                    ViewName = viewName,
                    ViewModel = viewModel 
                });
        }
    }
