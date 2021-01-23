    string strVal = ini.ReadValue("Action", "User");
    if(string.IsNullOrEmpty(strVal))  //This will return true if the value is null or blank.
    {
        MessageBox.Show("Contact Admin."); //So the message will display only when value is not assinged.
    }
