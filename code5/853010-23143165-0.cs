    MediaPly _mp = null;
    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            _mp = new MediaPly();
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        _mp.LoadFile(openFileDialog1.FileName, this.panel1);
    }
    MediaPly _mp2 = null;
    private void button3_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            _mp2 = new MediaPly();
        }
    }
    private void button4_Click(object sender, EventArgs e)
    {
        _mp2.LoadFile(openFileDialog1.FileName, this.panel1);
    }
    MediaPly _mp3 = null;
    private void button5_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            _mp3 = new MediaPly();
        }
    }
    private void button6_Click(object sender, EventArgs e)
    {
        _mp3.LoadFile(openFileDialog1.FileName, this.panel1);
    }
