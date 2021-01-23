    private void Form1_Resize(object sender, EventArgs e)
    {
        int dist = 3;
        int span = (panel1.Width - dist * 2) / 3;
        groupBox1.Width = span;
        groupBox2.Left = groupBox1.Right + dist;
        groupBox2.Width = groupBox1.Width;
        groupBox3.Left = groupBox2.Right + dist;
        groupBox3.Width = groupBox1.Width;
    }
