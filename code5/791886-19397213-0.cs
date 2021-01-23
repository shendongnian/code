        static Button[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        arr = new Button[2];
        arr[0] = Button1;
        arr[1] = Button3;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BackColor = System.Drawing.Color.Blue;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BackColor = System.Drawing.Color.Red;
        }
    }
