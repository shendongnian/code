    private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                if (!char.IsDigit(e.Text, e.Text.Length - 1))
                {
                    e.Handled = true;
                }
            }
