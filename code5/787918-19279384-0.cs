    protected void ButtonResize(Button button)
        {
            if (button != null && button.BackgroundImage != null)
            {
                button.BackgroundImage = new Bitmap(button.BackgroundImage, new Size(newWidth, newHeight));
            }
         }
