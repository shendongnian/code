    if (button1.BackgroundImage == null || button1.BackgroundImage.Width == 0)  // Error on this line
    {
        button1.BackgroundImage = Properties.Resources.SubmitButton; // Works fine if put out of conditon
    }
    else
    {
        button1.BackgroundImage = null;
    }
