    private void myComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
            // holds the list of combobox items as strings
            List<String> items = new List<String>();
    
            // indicates whether the new character added should be removed
            bool shouldRemoveLastChar = true;
    
            for (int i = 0; i < cbEffectOn.Items.Count; i++)
            {
                items.Add(cbEffectOn.Items.GetItemAt(i).ToString());
            }
    
            for (int i = 0; i < items.Count; i++)
            {
                // legal character input
                if (e.Text != "" && items.ElementAt(i).StartsWith(e.Text))
                {
                    shouldRemoveLastChar = false;
                    break;
                }
            }
    
            e.handled = shouldRemoveLastChar;
        }
