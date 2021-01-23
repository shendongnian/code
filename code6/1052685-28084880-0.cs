        public CustomWindow()
        {
            SizeChanged += CustomWindow_SizeChanged;
        }
        void CustomWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ToggleRestoreButtonIcon();
        }
        protected void ToggleRestoreButtonIcon()
        {          
           if (WindowState == WindowState.Maximized)
           {
             if (restoreButton != null)
             { 
                  //in wingdings, 1 is for maximized glyph
                  // you can set it to whatever content you want
                  restoreButton.Content = "1"; 
             } 
           } 
           else
           {              
              if (restoreButton != null)
              {
                  //in wingdings, 2 is for "restore" glyph
                  // you can set it to whatever content you want                   
                   restoreButton.Content = "2"; 
              } 
           }
        }
