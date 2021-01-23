        StringBuilder yachtTypesString = new StringBuilder();
        for (int indexInteger = 0; indexInteger < typeComboBox.Items.Count; indexInteger++)
        {
            yachtTypesString.AppendLine(typeComboBox.Items[indexInteger].ToString());
        }
        MessageBox.Show(yachtTypesString.ToString());
