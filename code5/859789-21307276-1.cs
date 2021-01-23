    public static class StatusHelper
    {
        private static SmStatusBar _statusBar;
        
        static StatusHelper()
        {
            _statusBar = CommonHelper.SmMainWindow.StatusBar;
        }
         public static bool UpdateStatus(string text)
         {
             _statusBar.UpdateStatusText(text);
             return true;
         }
    }
