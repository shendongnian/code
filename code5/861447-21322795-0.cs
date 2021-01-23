    private void ButtonAction_OnClick(object sender, EventArgs e)
    {
        Button button = sender as Button;
        Image bImage = button.BackgroundImage;
        if(bImage.Tag.Equals(...))
        {
            //do something
        }
        else //do something else
     }
