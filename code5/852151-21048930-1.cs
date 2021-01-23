     protected void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TextBox1.Text = button.Text;
        }
