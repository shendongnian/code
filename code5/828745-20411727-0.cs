    void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
    {
        CalculateNewSizeFactor(e.Delta);
        pictureBox1.Image = resizeImage(img, new Size((int)(img.Width * factor), (int)(img.Height * factor)));
    }
    private void CalculateNewSizeFactor(int delta)
    {
        if (delta > 0 && factor < 2)
        {
            factor *= increment;
        }
        else if (delta < 0 && factor > 0.25)
        {
            factor /= increment;
        }
    }
