    string DefaultLabelValue="";
    private void Form1_Load(object sender, EventArgs e)
    {
        DefaultLabelValue=lable1.Text;
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
            label1.Text = textBox1.Text + label1.Text;
        else
            label1.Text = DefautLabelValue;
    }
