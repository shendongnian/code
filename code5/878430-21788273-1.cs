    // List 
    private List<String> checkedValues = new List<String>();
    public int nTextboxChanged = 0;
    // Button, just ignore all the crap inside
    private void saveChangesButton_Click(object sender, RoutedEventArgs e)
    {
        if(nTextboxChanged == 1)
        {     
            checkedValues.Add(sWidth.Text);
            System.IO.File.WriteAllLines(@System.IO.File.ReadAllText(@System.IO.Directory.GetCurrentDirectory() + "/dir.txt") + "/commandline.txt", checkedValues);
        }
    }
    // TextChanged
    private void sWidth_TextChanged(object sender, TextChangedEventArgs e)
    {
        nTextboxChanged = 1;
    }
