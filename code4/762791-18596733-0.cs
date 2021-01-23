    private void BrowseFile()
    {
    //dlgopenfile is the name of Openfiledialog that allows the user to browse for a file.
    //string filename is the name of selected file if any.
    //Form2 is the next form.
    
    try
    {
    
    switch (dlgopenfile.ShowDialog())
    {
    case DialogResult.OK://If Ok(Yes) button is pressed on Openfiledialog.
    filename = dlgopenfile.FileName;
    break;
    
    case DialogResult.Cancel://If Cancel button is pressed on Openfiledialog.
    filename = "";
    break;
    }
    
    if (filename.Length >= 1)
    {
    if (File.Exists(filename) == true)
    {
    ButtonOpenFile.Enabled = true;
    }
    else
    {
    ButtonOpenFile.Enabled = false;
    throw new FileNotFoundException("The file you selected does not exist.");
    }
    }
    }
    catch (FileNotFoundException ex)
    {
    MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    }
