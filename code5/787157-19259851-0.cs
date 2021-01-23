    // property name "txtMod0x"
    string propertyName = "txtMod" + i.ToString().PadLeft(2, '0');
    // get the property from the current type
    PropertyInfo prop = this.GetType().GetProperty(propertyName);
    // get the property value (the TextBox in this case)
    var obj = prop.GetValue(this, null) as TextBox;
   
    string val = Convert.ToString((Convert.ToInt32(statArray.GetValue(i)) - 11) / 2);
    obj.Text = val;
