    private void MyTable_ColumnChanged(object sender, DataColumnChangeEventArgs e) {
       if (e.Column == MyTrueFalseColumn)
          CheckboxChanged(e);
    }
    
    private void CheckboxChanged(DataColumnChangeEventArgs e) {
       if (!(bool)e.ProposedValue && MustRemainChecked()) {
          MyCheckbox.Checked = true;
          MyCheckbox.DataBindings[0].WriteValue();
       }
    }
