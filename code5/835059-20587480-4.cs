    private void parisa(string directory)
    {
        if(directory.IndexOf("autorun.inf", StringComparison.OrdinalIgnoreCase) != -1)
        {
            MessageBox.Show("The USB is Viral");
        }
        ....
    }
