    private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int h = Convert.ToInt32(a);
   
            for (int i = 0; i <= h; i++)
            {
                var b = new Button { Size = new Size(60, 23), Location = new Point(4 + i * 57, 20), Text = string.Format("button{0}", i) };
                b.Click += b_Click;
                panel1.Controls.Add(b);
            }
        }
        void b_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
