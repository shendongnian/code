    public Form2(Form1 f1)
    {
        this.f1 = f1; // some field or property to hold Form1
    }
    private void button3_Click(object sender, EventArgs e)
    {
        MessageBox.Show("" + f1.text1);
    }
