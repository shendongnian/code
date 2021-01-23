    private void myComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Get the textbox part of the combobox
            TextBox textBox = cbEffectOn.Template.FindName("PART_EditableTextBox", cbEffectOn) as TextBox;
    
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
                if (textBox.Text != "" && items.ElementAt(i).StartsWith(textBox.Text))
                {
                    shouldRemoveLastChar = false;
                    break;
                }
            }
    
            e.handled = shouldRemoveLastChar;
        }
