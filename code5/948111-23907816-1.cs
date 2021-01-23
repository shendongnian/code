    private void Form1_Load(object sender, EventArgs e)
    {
        Form1 frm = new Form1();
        
        foreach (Control item in Controls)
        {
            if (item is Button)
            {
                item.MouseEnter += (s, ea) => { YourMethodName(); };
            }
        }
    }
    private void YourMethodName()
    {
        MessageBox.Show("Hi from mouse enter");
    }
