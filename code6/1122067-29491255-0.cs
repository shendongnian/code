    protected void Page_Load(object sender, EventArgs e)
    {
       // txtReadyTime.Text =""; //Button will be enabled
        txtReadyTime.Text =DateTime.Now.ToShortTimeString(); //Button will be enabled
        textboxenabled(txtReadyTime);
        //Button btn = this.FindControl("btnReadyTime") as Button;
        //Title = btn.Text;
    }
    public void textboxenabled(TextBox box)
    {
        string btnName = box.ID.Replace("txt", "btn");
        try
        {
            Button btn = FindControl(btnName) as Button;
            if (box.Text == "")
                btn.Enabled = true;
            else
                btn.Enabled = false;
        }
        catch
        {
        }
    }
