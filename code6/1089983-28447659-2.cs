    public void PutRandomImagesOnButtons(Button[] buttons, Bitmap[] images)
    {
        var rand = new Random();
        foreach (var btn in buttons)
        {
            btn.BackgroundImage = images[rand.Next(images.Length)];
        }
    }
