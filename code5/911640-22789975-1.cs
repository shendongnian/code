    private OpenFileDialog OpenFileDialog {get;set;}
    public Ctor()
    {
        OpenFileDialog = new OpenFileDialog();
    }
    private void btnOpen_Click(object sender, RoutedEventArgs e)
    {
        ...
        ... OpenFileDialog.ShowDialog();
        ...
    }
