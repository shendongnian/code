    public static Platform DetectPlatform()
    {
        bool isHardwareButtonsAPIPresent =
            ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
        if (isHardwareButtonsAPIPresent)
        {
            return Platform.WindowsPhone;
        }
        else
        {
            return Platform.Windows;
        }
    }
