    public static bool IsAlertPresent()
    {
        try
        {
            SeleniumDrivers.driver.SwitchTo().Alert();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
