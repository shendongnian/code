    private void ButtonClick()
    {
        CustomControl.PersonResult newControl = new CustomControl.PersonResult();
        this.panel1.Controls.Add(newControl);
        newControl.PictureBox.WaitOnLoad = false;
        newControl.PictureBox.LoadAsync("http://url-here.com/image.jpg");
    }
