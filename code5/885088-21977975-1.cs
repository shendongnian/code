    private void btnConvert_Click(object sender, EventArgs e)
    {
        ConvertImage ci = new ConvertImage();
        try
        {
            ci.ImagePath(@"C:\tryConvert\LP_10078.eps")
            MessageBox.Show("Success!");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
