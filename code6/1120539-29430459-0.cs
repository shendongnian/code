    double total = 0;
            if (string.IsNullOrWhitespace(TextBox1.Text))
               TextBox1.Text = "0";
            if (string.IsNullOrWhitespace(TextBox2.Text))
               TextBox2.Text = "0";
            if (string.IsNullOrWhitespace(TextBox3.Text))
               TextBox3.Text = "0";
            total = int.Parse(TextBox1.Text) * 0.10;
            total = total + (int.Parse(TextBox2.Text) * 20);
            total = total + (int.Parse(TextBox2.Text) * 30);
            Lbl.Text = total.ToString();
