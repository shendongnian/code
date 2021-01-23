    private string[] lines;
    public void button13_Click(object sender, EventArgs e)
    {
        lines = File.ReadAllLines(openFileDialog1.FileName);
        timer1.Start();
    }
