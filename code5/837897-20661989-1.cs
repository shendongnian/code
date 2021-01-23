    private void OpenImage()
    {
        foreach (string strFileName in Directory.GetFiles(Server.MapPath("~/img/")))
        {
            ImageButton imageButton = new ImageButton();
            ...
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes["class"] = "my-class"; // or div.Attributes.Add("class", "my-class"); 
            div.Controls.Add(imageButton);
            Panel1.Controls.Add(div);
        }
    }
