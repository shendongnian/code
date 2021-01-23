    public static class ControlExtension
    {
        public static void HookFocusChangeBackColor(this Control ctrl, Color focusBackColor)
        {
            var originalColor = ctrl.BackColor;
            var gotFocusHandler = new EventHandler((sender, e) => 
            { 
                (ctrl as Control).BackColor = focusBackColor; 
            });
            var lostFocusHandler = new EventHandler((sender, e) => 
            { 
                (ctrl as Control).BackColor = originalColor; 
            });
    
            ctrl.GotFocus -= gotFocusHandler;
            ctrl.GotFocus += gotFocusHandler;
    
            ctrl.LostFocus -= lostFocusHandler;
            ctrl.LostFocus += lostFocusHandler; 
        }
    }
