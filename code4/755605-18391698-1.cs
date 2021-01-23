    public void ProxyShowMessageBox(ShowMessageBoxDelegate showMessageBoxDelegate)
    {
        if (showMessageBoxDelegate != null)
        {
            bool result = showMessageBoxDelegate("MessageBox message");
        }
    }
