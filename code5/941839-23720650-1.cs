        private bool ValidateTextBoxes()
        {
            try
            {
                string textBoxData = string.Empty;
                foreach (Control item in this.Controls)
                {
                    if (item.GetType() == typeof(TextBox))
                    {
                        textBoxData += item.Text;
                    }
                }
                return (textBoxData != string.Empty);
            }
            catch { return false; }
        }
       
        if(ValidateTextBoxes())
        {
             // your code..
        }
