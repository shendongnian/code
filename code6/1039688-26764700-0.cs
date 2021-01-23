    private void button1_Click(object sender, EventArgs e)
    {
        PrintClass pc = new PrintClass();
        Font ft = new System.Drawing.Font("Arial", 12.5f);
        pc.changevalues("Hello", ft);
        pc.print();
    }
