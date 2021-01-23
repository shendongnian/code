    if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Equals("username"))
    {
        button1.Visible = true;
    }
    else
    {
        button1.Visible = false;
    }
