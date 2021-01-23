        protected void calculateLabs(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
                {
                    int num1 = Convert.ToInt32(TextBox1.Text);
                    int num2 = Convert.ToInt32(TextBox2.Text);
                    int final = num1 + num2;
                    Label1.Text = final.ToString();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
