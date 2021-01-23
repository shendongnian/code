        private bool CheckTextBox()
        {
            bool isValid = true;
            foreach(TextBox txt in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    isValid = false;
                    MessageBox.Show("Please insert data correctly");
                    break; //You only need one invalid input to prevent saving
                }
            }
            return isValid;
        }
