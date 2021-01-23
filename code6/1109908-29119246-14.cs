     public void ShowPopup()
     {
         var popup = IoC.Get<PopupViewModel>();
         _windowManager.ShowWindow(popup);
     }
