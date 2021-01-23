    int cbNumber = 0;
    try
    {
        cbNumber = System.Convert.toInt32(((CheckBox)sender).name.Replace("checkbox",""));
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
    }
