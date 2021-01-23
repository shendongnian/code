        if (!IsPostBack)
        {
            getImage();
        }
    }
    private void getImage()
    {
        Random rand = new Random();
        int i = rand.Next(1, 6);
        Image1.ImageUrl = "~/image/" + i.ToString() + ".jpg";
        Label1.Text = "image no :" + i.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        getImage();
    }
