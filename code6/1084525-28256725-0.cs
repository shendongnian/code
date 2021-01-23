    int index = 0;
    private void anImageButton_Click(object sender, EventArgs e)
    {
        index = (index + 1) % 6;
        anImageButton.Image = 
              (Bitmap)MyProject.Resource1.ResourceManager.GetObject("_" + index);
    }
