    private void Form1_Load(object sender, EventArgs e)
    {              
        foreach (Control item in this.Controls)
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
