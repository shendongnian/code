    static bool ValidateFormat(string customFormat)
    {
        return !String.IsNullOrWhiteSpace(customFormat) && customFormat.Length > 1 && DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns().Contains(customFormat);
    }
    static bool ValidateFormat(string customFormat)
    {
        try
        {
            DateTime.Now.ToString(customFormat);
            return true;
        }
        catch
        {
            return false;
        }
    }
