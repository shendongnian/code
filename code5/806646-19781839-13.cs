    public void setPicture(Image img)
    {
        this.BackgroundImage = img;
        this.Text = img.Tag.ToString(); //The image's Tag property is an object so it needs to be converted to a string
    }
