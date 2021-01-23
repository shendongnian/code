    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = this.DataContext;
            (this.DataContext as ViewModel).MyProperty = text1.Text;
        }
