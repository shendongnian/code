    private void gender_SelectionChanged(object sender, TextChangedEventArgs e)
     {
            var currentText = (sender as ComboBox).SelectedItem as string;
    
            if (currentText.Equals("Male"))
            {
                sex.Text = "m";
            }
            if (currentText.Equals("Female"))
            {
                sex.Text = "f";
            }
     }
   
