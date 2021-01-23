    public string GetPhoneExtension(string phoneExtension)
    {
        if((String.IsNullOrEmpty(phoneExtension) || (phoneExtension.Length == 4))
        {
            return "N/A";
        }
        return phoneExtension;
    }
