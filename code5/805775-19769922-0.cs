        string previousInput = "";
        private void InputTextbox_TextChanged(object sender, RoutedEventArgs e)
        {
            Regex r = new Regex("^\d+.\d*$"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(InputTextbox.Text);
            if (m.Success)
            {
                previousInput = InputTextbox.Text;
            }
            else
            {
                InputTextbox.Text = previousInput;
            }
        }
