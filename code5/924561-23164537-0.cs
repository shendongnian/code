    private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        switch (((ComboBoxItem)secondaryTable.SelectedItem).Content.ToString())
        {
            case "Agents": 
                stCombo1.ItemsSource = tableArray; 
                stCombo2.ItemsSource = tableArray; 
                break;
            case "Missions":
                stCombo1.ItemsSource = attributeArray; 
                stCombo2.ItemsSource = attributeArray; 
                break;
            default: 
                stCombo1.ItemsSource = jobsArray; 
                stCombo2.ItemsSource = jobsArray; 
                break;
        }
    }
