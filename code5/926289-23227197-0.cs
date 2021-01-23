    private bool isChecked;
    public bool  IsChecked
    {
        get
        {
             if(this.SelectedItem != null)
             {
                 return this.selectedItem.IsChecked;
             }
             return false;
        }
        set
        {
            this.isChecked = value;
        }
    }
