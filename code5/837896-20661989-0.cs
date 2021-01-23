    private void OpenImage()
    {
        foreach (string strFileName in Directory.GetFiles(Server.MapPath("~/img/")))
        {
            ImageButton imageButton = new ImageButton();
            ...
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Controls.Add(imageButton);
            Panel1.Controls.Add(div);
        }
    }
