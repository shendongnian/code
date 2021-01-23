    private void initializeDgvNotesDataSource()
    {            
        List<ComboBoxItem> list = new List<ComboBoxItem>();
        BindingList<ComboBoxItem> bindingList = new BindingList<ComboBoxItem>(list);
        BindingSource bindingSource = new BindingSource();
        bindingSource.DataSource = bindingList;
        dgvNotes.DataSource = bindingSource;
    }
