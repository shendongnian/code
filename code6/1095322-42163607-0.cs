     private void _capitalizeFirstWord(Object sender, KeyPressEventArgs e)
            {
               if (_richTB.Text.Trim() == String.Empty)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
