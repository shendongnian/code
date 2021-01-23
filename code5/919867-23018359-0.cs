    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 2; i++)
        {
            p[i] = new Panel();
            p[i].Visible = false;
            p[i].Size = new Size(200, 100);
            p[i].Location = new Point(41, 103);
            this.Controls.Add(p[i]);   // You need this line to add panel to form
        }
        p[0].BackColor = System.Drawing.Color.Red;
        p[1].BackColor = System.Drawing.Color.Blue;
    }
