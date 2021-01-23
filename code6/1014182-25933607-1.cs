    private void RemoveLastButton_Click(object sender, RoutedEventArgs e)
    {
        RemoveLastButton(DotControl, Count, tb)
    }
    private void RemoveLastButton(bool DotControl, int Count, TextBox tb)
    {
        if (Tb != null && Tb != DriverTextBox)
        {
            try
            {
                var keypadObject = new Keypad();
                keypadObject.RemoveLast(Tb, DotControl, Count);
            }
            catch (Exception)
            {
                TotalTextBox.Focus();
            }
        }
        else
        {
            TotalTextBox.Focus();
        }
    }
