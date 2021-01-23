    try
    {
        UpdateStatus("Loading " + dlg.FileName);
        pbxPhoto.Image = new Bitmap(dlg.OpenFile());
        UpdateStatus("Loaded " + dlg.FileName);
        MessageBox.Show("Text = " + dlg.FileName); 
    }
    catch (Exception ex)
    {
        UpdateStatus("Unable to load file " + dlg.FileName);
        MessageBox.Show("Unable to load file: " + ex.Message);
    }
