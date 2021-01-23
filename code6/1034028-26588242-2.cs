    try
    {
        pictureBox1.Image = Bitmap.FromFile(@"C:\img.jpg");
    }
    catch(Exception ex)
    {
         MessageBox.Show(ex.ToString());
    }
