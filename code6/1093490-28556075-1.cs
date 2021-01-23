        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
           var selectedItem= combobox.SelectedItem as ComboBoxItem; 
           if(selectedItem!=null)
           {
               string name = selectedItem.Name;
               Expander expander = new Expander { Header = name };
               dock.Children.Add(expander);
           }
        }
    
