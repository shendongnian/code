    public void monothers_TextChanged(object sender, TextChangedEventArgs e)
    {
       var binding = ((TextBox)sender).).GetBindingExpression(TextBox.TextProperty);
       binding.UpdateSource();
    }
