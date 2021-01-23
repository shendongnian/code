    if (l != null)
    {
        _accountID = (int)l.AccountIDFK;
        _securityLevelID = (int)l.SecurityLevelIDFK;
        if (_accountID < 1 || _accountID == null)
        {
            lbl_LoginStatus.Text = "Invalid";
        }
    }
    else
    {
        // logic when l is null
    }
