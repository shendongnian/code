        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Button_Add((Button)sender);
        }
        private void Button_Add(Button button)
        {
            var tb = Keyboard.FocusedElement as TextBox;
            try
            {
                var keypadObject = new Keypad();
                keypadObject.AppendValue(tb, button.Content.ToString());
            }
            catch (Exception)
            {
                TotalTextBox.Focus();
            }
        }
