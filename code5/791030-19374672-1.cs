           private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                try
                {
                    Convert.ToInt32(e.Text);
                }
                catch
                {
                    e.Handled = true;
                }
            }
