    public void ShowImage(System.Drawing.Image x)
    {
        if (pictureBox1.InvokeRequired)
        {
            pictureBox1.Invoke(new voidstringfunction(ShowImage), x);
            return;
        }
        pictureBox1.Image = x;
        pictureBox1.Update();
    }
