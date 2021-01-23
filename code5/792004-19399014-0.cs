    propertyGrid.PropertyValueChanged+=  new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged ); 
    private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) 
        { 
            if (e.ChangedItem.Label == "???" && !IsValid((int)e.ChangedItem.Value) ) 
            { 
                // the entered value is wrong - show error message 
                e.ChangedItem.PropertyDescriptor.SetValue( propertyGrid.SelectedObject, e.OldValue); 
                MessageBox.Show("Wrong Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            } 
        }
 
        private static bool IsValid( int inputData) 
        { 
          // logic here
        } 
