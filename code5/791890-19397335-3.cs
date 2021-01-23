    Button[] arr;
    protected void btnColor_Click(object sender, EventArgs e)
    {
        ChangeColorRed();
    }
    protected void btnColor2_Click(object sender, EventArgs e)
    {
        ChangeColorGreen();
    }
    public void ChangeColorRed()
    {
        SetButton();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BackColor = System.Drawing.Color.Red;
        }
    }
    public void SetButton()
    {
        arr = new Button[2];
        arr[0] = btn1;
        arr[1] = btn2;
    }
    public void ChangeColorGreen()
    {
        SetButton();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BackColor = System.Drawing.Color.Green;
        }
    }
