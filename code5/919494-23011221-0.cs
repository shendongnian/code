     protected void Page_Load(object sender, EventArgs e)
        {
            Image img = new Image();
            img.ImageUrl = "~/Images/hello.jpg";
            Page.Controls.Add(img);
        }
