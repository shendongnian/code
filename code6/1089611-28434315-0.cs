    public void Script()
    {
        string str = "error";
        if (!CheckStr(str))
        {
            return;
        }
        // ...continue
    }
    public bool CheckStr(string str)
    {
        if (str == "error")
        {
            return false;
        }
        // ...additional checks
        return true;
    }
