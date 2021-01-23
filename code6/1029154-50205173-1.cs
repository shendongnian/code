     private void OnComboBoxLoad(object sender, RoutedEventArgs e)
        {
            //store current selcted index in variable
            int tempIndex = ((ComboBox)sender).SelectedIndex;
            
            //// ... Make the your desire item selected.
            ((ComboBox)sender).SelectedIndex = -1;
            ((ComboBox)sender).SelectedIndex = tempIndex ;
        }
