    public CustomerType Value
    {
        get { return this.value; }
        set
        {
            this.value = value;
            if (value != null)
                textBoxSearch.Text = value.Description;
            else
                textBoxSearch.Clear();
            valueChanged = true;
            if ((EditingControlDataGridView.CurrentCell as CustomerTypeCell) != null)
                (EditingControlDataGridView.CurrentCell as CustomerTypeCell).Value = value;
        }
    }
