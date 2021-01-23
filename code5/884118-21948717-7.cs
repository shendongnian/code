    if (listBox1.SelectedItem == null)
    {
        System.Diagnostics.Debug.WriteLine("Selection is null");
        return;
    }
    try
    {
        File.Delete(Path.Combine(folderBrowserDialog1.SelectedPath,
                                 listBox1.SelectedItem.ToString()));
    }
    catch (System.IO.IOException e)
    {
        System.Diagnostics.Debug.WriteLine(e.Message);
    }
