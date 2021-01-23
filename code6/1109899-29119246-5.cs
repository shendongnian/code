    public class ModernWindowManager : WindowManager
    {
        protected override Window EnsureWindow(object rootModel, object view, bool isDialog)
        {
            var window = view as ModernWindow;
    
            if (window == null)
            {
                window = new ModernWindow();
                window.SetValue(View.IsGeneratedProperty, true);
            }
    
            return window;
        }
    }
