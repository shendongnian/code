    public bool Exists(By by)
    {
        if (Driver.Instance.FindElements(by).Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
