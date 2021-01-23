    enum enCountries:int{India=0,USA,UK,UAE};// Declare Enum
    string[] enumNames=Enum.GetNames(typeof(enCountries)); //convert into string array
    foreach (string item in enumNames)
    {
    //get the enum item value
    int value = (int)Enum.Parse(typeof(enCountries), item);
    ListItem listItem = new ListItem(item, value.ToString());
    dropdown.Items.Add(listItem); // bind dropdown
    }
