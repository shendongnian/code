    public bool Exists(By by)
    {
        if (Driver.Instance.FindElements(by).Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
