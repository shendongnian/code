    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
       Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
       e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart,e.Text));
    }
