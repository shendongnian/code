    Binding binding = new Binding("SelectAll");
    binding.Mode = BindingMode.TwoWay;
                
    CheckBox headerCheckBox = new CheckBox();
    headerCheckBox.Content = "Title";
    headerCheckBox.SetBinding(CheckBox.IsCheckedProperty, binding);
                
    DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn();
    checkBoxColumn.Header = headerCheckBox;
    checkBoxColumn.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    checkBoxColumn.Binding = new Binding(e.PropertyName);
    checkBoxColumn.IsThreeState = true;
