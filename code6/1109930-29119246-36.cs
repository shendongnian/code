    public class MyViewModel 
    {
        private PopupViewModel _popup;
        private IWindowManager _windowManager;
    
        public MyViewModel(PopupViewModel popup, IWindowManager windowManager) 
        {
            _popup = popup;
            _windowManager = windowManager;
        }
    
        public void ShowPopup()
        {
            _windowManager.ShowPopup(_popup);
        }    
    }
