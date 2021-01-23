    private bool isViewUpToDate = false;
    private void DataGrid_SelectionChanged(object sender, EventArgs e) => isViewUpToDate = false;
    public void CheckDataGridSelectionView()
    {
        if (isViewUpToDate)
            return;
        
        // Logic goes here
        
        isViewUpToDate = true;
    }
    
    static void Main()
    {
        Application.Idle += (sender, eventData) => MainForm.Instance?.CheckDataGridSelectionView();
        
        // ...
    }
