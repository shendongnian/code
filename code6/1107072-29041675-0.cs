    if (e.Control && char.IsLetterOrDigit((char) e.KeyCode))
                {
                    txtBox.Text += (new KeysConverter()).ConvertToString(e.KeyCode);
                    e.Handled = true;
                }
