            textBox1.TextChanged += (s, _) =>
            {
                if (!textBox2.Focused && textBox1.Text != textBox2.Text)
                {
                    textBox2.Text = textBox1.Text;
                }
            };
            textBox2.TextChanged += (s, _) =>
            {
                if (!textBox1.Focused && textBox2.Text != textBox1.Text)
                {
                    textBox1.Text = textBox2.Text;
                }
            };
