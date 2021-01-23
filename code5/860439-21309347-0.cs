       public interface IWindowService
       {
        void Open<TWindow>(ViewModelBase viewModel)
            where TWindow : Window;
       }
    
        public class WindowService : IWindowService
        {
            private readonly IUIDispatcher _dispatcher;
    
            public WindowService(IUIDispatcher dispatcher)
            {
                _dispatcher = dispatcher;
            }
    
            public void Open<TWindow>(ViewModelBase viewModel)
                where TWindow : Window
            {
                _dispatcher.Run(() => OpenThreadSafe<TWindow>(viewModel));
            }
    
            private static void OpenThreadSafe<TWindow>(ViewModelBase viewModel) where TWindow : Window
            {
                var view = (TWindow) Activator.CreateInstance(typeof(TWindow), viewModel);
                view.Show();
            }
        }
    public class UIDispatcher : IUIDispatcher
    {
        public void Run(Action action)
        {
            var dispatcher = DispatcherHelper.UIDispatcher;
            if (dispatcher == null)
            {
                action();
                return;
            }
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
