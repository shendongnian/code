    public bool CustomValidationDublicateName2(string sysPriority)
    {
        return (this.gridView.Items.SourceCollection as IEnumerable<SystemPriority>)
             .All(item => item.ID < 0 
                       || item.Title != sysPriority 
                       || item == (SystemPriority)this.gridView.SelectedItem);
    }
