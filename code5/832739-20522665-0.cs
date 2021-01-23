    public bool CustomValidationDublicateName2(string sysPriority)
    {
        return (this.gridView.Items.SourceCollection as IEnumerable<SystemPriority>)
             .Where(item => item.ID > 0)
             .All(item => item.Title != sysPriority || item == (SystemPriority)this.gridView.SelectedItem);
    }
