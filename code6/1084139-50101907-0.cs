    Outlook.MailItem mItem = (Outlook.MailItem)item;
    string udpName = "";
    string udpValueString = "";
    Debug.Print(" mItem.UserProperties.Count: " + mItem.UserProperties.Count);
    for (int i = 1; i <= mItem.UserProperties.Count; i++) {
        udpName = mItem.UserProperties[i].Name;
        var udpValue = mItem.UserProperties[i].Value;
        udpValueString = udpValue.ToString();
        Debug.Print(i + ": " + udpName + ": " + udpValueString);
    }
