    private static void TestChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var textBox = (TextBox)o;
            // start listening
            textBox.LayoutUpdated += SomeMethod();
        }
       private static void SomeMethod(...)
       {
          // this will be called very very often
          var expr = textBox.GetBindingExpression(TextBox.TextProperty); 
          if(expr != null)
          {
            // finally you got the value so stop listening
            textBox.LayoutUpdated -= SomeMethod();
