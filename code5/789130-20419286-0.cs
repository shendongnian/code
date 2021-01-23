    protected override void OnValueChanged(EventArgs eventargs)
    {
        valueChanged = true;
        // Notify the DataGridView that the contents of the cell 
        // have changed.
           
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
        isChecked();
    }
    public bool isChecked()
    {
        bool isChecked = false;
         if (this.Checked)
        {
            this.Checked = true;
            this.Format = DateTimePickerFormat.Short;
            isChecked = true;
        }
        else if (!this.Checked)
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " ";
            isChecked = false;
        }
         return isChecked;
    }
