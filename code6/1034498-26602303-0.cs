    private void Form1_Resize(object sender, EventArgs e)
    {
        int span = broadTextBox.Width / 3 ;
        int dist = (groupBox1.Right - groupBox2.Left);
        groupBox1.Width = span - 2 * dist;
        groupBox2.Width = groupBox1.Width;
        groupBox3.Width = groupBox1.Width;
        groupBox2.Left = groupBox1.Right + dist;
        groupBox3.Left = groupBox2.Right + dist;
    }
