    void mailItem_PropertyChange(string propertyName)
    {
        if (string.Equals(propertyName, "BCC"))
        {
            MessageBox.Show(mailItem.BCC);
        }
    }
