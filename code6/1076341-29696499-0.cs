    private void ComboBox_TextInput_1(object sender, TextCompositionEventArgs e)
        {           
            cmbperson.IsDropDownOpen = true;
            cmbperson.ItemsSource = DataBase.Persons.Where(p => p.Name.Contains(e.Text)).ToList();
        }
