    protected void button1_Click(object sender, EventArgs e)
    {
       WebControlDemo wcd = this.LoadControl("~/SomePath/WebControlDemo.ascx") as WebControlDemo;
       this.placeHolder1.Controls.Add(wcd);
    }
