    private void Form1_Load(object sender, EventArgs e)
    {              
        foreach (Control item in this.Controls)
        {
            if (item is Button)
            {
                //item.MouseEnter += (s, ea) => { YourMethodName(); };
                  item.MouseEnter += new System.EventHandler(btn_MouseEnter);
            }
        }
    }
    private void btn_MouseEnter(object sender, System.EventArgs e)
    {
       //your code to increase width and height
        var btnSenderButton = sender as Button;
        btnSenderButton.Width += 30;
    }
