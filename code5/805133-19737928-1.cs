    public string SomethingPicked { get; private set; }
    
    private void somethingListView_ItemActivate(object sender, EventArgs e)
    {
        SomethingPicked = somethingListView.SelectedItem[0].ToString();
        DialogResult = DialogResult.OK;
    }
