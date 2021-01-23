        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string a = textBox1.Text;
            int h = Convert.ToInt32(a);
        
            for (int i = 0; i <= h; i++)
            { 
                var btn = new Button {Size = new Size(60, 23), Dock=DockStyle.Left, Text=h.ToString() };
                btn.Click+= delegate(object sender, EventArgs e)  { //your commands }; 
                panel1.Controls.Add(btn);
            }
        }
