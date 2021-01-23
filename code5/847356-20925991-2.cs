    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FUFile.PostedFile != null)
        {
            string tempVar = "~/res/Posts/" + FUFile.Value.ToString();
            FUFile.PostedFile.SaveAs(Server.MapPath(tempVar));
        }
    }
