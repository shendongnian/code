    if (comboBox2.SelectedItem != null) {
      string SelectedItemName = comboBox2.SelectedItem.ToString();
    
      Console.WriteLine(SelectedItemName);
      testvariabel2.GetSessionName();
    }
    else {
      // No selected item in the ComboBox
    }
    
    ...
    
    if (_form1Object != null)
      if (_form1Object.comboBox2.SelectedIndex >= 0) {
        string SelectedItemName = _form1Object.comboBox2.SelectedItem.ToString();
        System.Threading.Thread.Sleep(1000);
    
        if (newDictionary.ContainsKey(SelectedItemName))
          ...
       }
