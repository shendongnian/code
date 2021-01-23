    in xaml
        <TextBox TextChanged="OnTextBoxTextChanged" Text="{Binding MyText, Mode=TwoWay, UpdateSourceTrigger=Explicit}" />
    
    in C#
    
        private void OnTextBoxTextChanged( object sender, TextChangedEventArgs e )
        {
          TextBox textBox = sender as TextBox;
          // Update the binding source
          BindingExpression bindingExpr = textBox.GetBindingExpression( TextBox.TextProperty );
          bindingExpr.UpdateSource();
        }
