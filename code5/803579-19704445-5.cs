    public string SelectedItem
    {
        get { return selectedItem; }
        set 
        {
            selectedItem = value;
            NotifyPropertyChanged("SelectedItem");
            if (selectedItem == "Some value") 
            {
                IsControl1Visible = true;
                IsControl2Visible = false;
            }
            else
            {
                IsControl2Visible = true;
                IsControl1Visible = false;
            }
        }
    }
