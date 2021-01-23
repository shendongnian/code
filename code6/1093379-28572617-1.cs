    var pwd = _Password;
    if (pwd == null)
    {
        pwd = string.Empty;
    }
    return Shell.ToolBox.Cryptography.GetMD5(pwd);
