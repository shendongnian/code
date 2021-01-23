    // property name "txtMod0x"
    string propertyName = "txtMod" + i.ToString().PadLeft(2, '0');
    // get the property from the current type
    PropertyInfo prop = this.GetType().GetProperty(propertyName);
    if (prop != null)
    {
        // get the property value (the TextBox in this case)
        var textBox = (TextBox)prop.GetValue(this, null);
   
        string val = Convert.ToString((Convert.ToInt32(statArray.GetValue(i)) - 11) / 2);
        textBox.Text = val;
    }
