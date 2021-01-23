    private void Save_Click(object sender, RoutedEventArgs e) {
    
        // create validation object 
        RowDataInfoValidationRule rule = new RowDataInfoValidationRule();
    
        StringBuilder builder = new StringBuilder();
    
        // enumerate all rows
        for (int i = 0; i < dgReceiveInventory.Items.Count; i++) {
            DataGridRow row = (DataGridRow) dgReceiveInventory.ItemContainerGenerator.ContainerFromIndex(i);
    
            // validate rule
            ValidationResult res = rule.Validate(row.BindingGroup, null);
    
            if (!res.IsValid) {
                // collect errors 
                builder.Append(res.ErrorContent);
            }
        }
    
        //show message box
        MessageBox.Show(builder.ToString());
    }
