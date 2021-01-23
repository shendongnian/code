     private void Button1_Click(object sender, RoutedEventArgs e)
       {
          
          Debug.Print("'Set DataContext' button clicked");
          tb.DataContext = _vm;
          var bindingExp = tb.GetBindingExpression(TextBox.TextProperty);
          bingExp.UpdateSource();
       }
