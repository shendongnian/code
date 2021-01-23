        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            double input;
            if(double.TryParse(textBox1.Text, out input))
            {
                if(input < 1 || input > 1000)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            else
                e.Cancel = true;
            if(e.Cancel)
                MessageBox.Show("Invalid input!");
        }
