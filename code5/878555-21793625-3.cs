    JArray jArray = JArray.Parse(jsonStr);
    bool isDefault;
    string defaultValue;
    foreach (JObject jObject in jArray.Children<JObject>())
    {
        isDefault = false;
        // check if current jObject contains a property named "selected"
        // and if the value is true
        JProperty p = jObject.Properties().SingleOrDefault(x => x.Name == "selected");
        if (p != null && (bool)p.Value == true)
        {
            isDefault = true;
        }
        foreach (JProperty jProperty in jObject.Properties())
        {
            string name = jProperty.Name.Trim();
            string value = jProperty.Value.ToString().Trim();
            if (name != "selected")
            {
                drpValues.Items.Add(new RadComboBoxItem(name, value));
                if (isDefault)
                {
                    defaultValue = value;
                }
            }
        }
    }
    // set the dropdown selected item
    RadComboBoxItem itemToSelect = drpValues.FindItemByValue(defaultValue);
    itemToSelect.Selected = true;
