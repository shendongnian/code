    private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in this)
            {
                c.GotFocus += new EventHandler(AnyControl_GotFocus);
            }
        }
    void AnyControl_GotFocus(object sender, EventArgs e)
        {
            //...
        }
