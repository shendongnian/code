                string yachtTypesString="";
        for (int indexInteger = 0; indexInteger < typeComboBox.Items.Count; indexInteger++)
        {
            yachtTypesString=yachtTypesString +  typeComboBox.Items[indexInteger].ToString();
            
        }
         MessageBox.Show(yachtTypesString);
