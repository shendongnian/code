        public CustomWindow()
        {
            SizeChanged += CustomWindow_SizeChanged;
        }
        void CustomWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
             CheckRestoreButtonIcon();
        }
        protected void CheckRestoreButtonIcon()
        {          
            //i'm assuming that the button is named as restoreButton.
            //in wingdings, 1 is for maximized glyph, 2 is for restore glyph
            // you can always set content to whatever you want!
            if (restoreButton == null)
                return;
            if (WindowState == WindowState.Maximized)
                restoreButton.Content = "1"; //maximizee glyph
            else
                restoreButton.Content = "2";//restore glyph
        }
