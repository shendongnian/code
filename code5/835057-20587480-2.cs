    private void parisa(string directory)
    {
        if(directory.IndexOf("autorun.inf", StringComparison.InvariantCultureIgnoreCase) != -1)
        {
            MessageBox.Show("The USB is Viral");
        }
        ....
    }
