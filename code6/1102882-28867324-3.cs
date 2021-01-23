        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() != "")
            {
                try
                {
                    obedomitor = Convert.ToDouble(TextBox1.Text.Trim());
                    fc.SetCurrentReading(obedomitor);
                    UpdateResults();
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number");
                    TextBox1.Text = "";
                }
            }
        }
