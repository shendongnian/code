    protected void Page_Load(object sender, EventArgs e)
    {
        Btnnew.Visible = true;
        FU.Visible = false;
        Btnok.Visible = false;
        U.Update();
    }
    protected void Btnnew_Click(object sender, EventArgs e)
    {
        Btnnew.Visible = false;
        FU.Visible = true;
        Btnok.Visible = true;
        U.Update();
    }
    protected void Btnok_Click(object sender, EventArgs e)
    {
        if (FU.HasFile)
        {
            string fileName = FU.FileName;
            FU.SaveAs(Server.MapPath("~/Images/") + fileName);// Assuming you have Images folder in the root
        }
        U.Update();
    }
