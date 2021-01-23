    private StreamReader sr;
    private void button1_Click(object sender, EventArgs e)
    {
        sr = new StreamReader(File.OpenRead(path)); //read file
        ProcessOneLine();
    }
    private void buttonNext_Click(object sender, EventArgs e)
    {
        ProcessOneLine();
    }
    private void ProcessOneLine()
    {
        if ( sr == null )
            return;
        string line = string.Empty;
        line = sr.ReadLine()
        if ( line == null )
        {
            sr = null;
            return;
        }
        string iw = encode.I_type(line);     //doWork
        textBox1.Text = (iw);
        label6.Text = (iw.Length).ToString();
        string strHex = encode.add_digits(Convert.ToInt32(iw, 2).ToString("X"), 8);
        textBox2.Text = strHex;
    }
