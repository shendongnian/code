    private void LoginEmail_LostFocus(object sender, RoutedEventArgs e)
    {
          var focusedControl = FocusManager.GetFocusedElement(this);
          if (focusedControl.GetType() != typeof(TextBox) || ((TextBox)focusedControl).Name != "LoginPassword")
          {
               UnfocusAnimation.Begin();            
          }
    }
