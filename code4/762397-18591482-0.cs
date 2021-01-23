    private void saveImage_Click(object sender, EventArgs e)
    {
        string str = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string path = str + "\\Image\\";
        string imgName = ofd.SafeFileName;
        try
        {
            File.Copy(ofd.FileName, path + imgName);
            MessageBox.Show("Image is saved");
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message.ToString());
        }
    }        
