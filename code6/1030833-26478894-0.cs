    private void checkBoxTest_Click(object sender, RoutedEventArgs e)
    {
                CheckBox checkBoxTest = e.Source as CheckBox;
                if (checkBoxTest == null)
                    return;
    
                if (checkBoxTest.Content.ToString().Contains("Select All") && checkBoxTest.IsChecked == true)
                {
                    foreach (object item in comboBoxTest.Items)
                    {
                        ComboBoxItem comboBoxItem = comboBoxTest.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItem;                   
                        if (comboBoxItem == null)
                        {
                            return;
                        }
                        CheckBox checkBox = FindVisualChildByName<CheckBox>(comboBoxItem, "checkBoxTest");
                        checkBox.IsChecked = true;
                    }
                }
    }
