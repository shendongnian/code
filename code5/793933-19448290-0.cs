    private void button1_Click(object sender, EventArgs e)
    {
        panel1.Controls.Clear();
        string a = textBox1.Text;
        int h = Convert.ToInt32(a);
    
        for (int i = 0; i <= h; i++)
        {
            panel1.Controls.Add(new Button {Size = new Size(60, 23), Dock=DockStyle.Left, Text=h.ToString() });
        }
    }
