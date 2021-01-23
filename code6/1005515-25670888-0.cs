     private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                e.Handled = true;
        }
