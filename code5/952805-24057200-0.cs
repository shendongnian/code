    public string[] win_List = new string[50];
    int i = 0;
    public bool lpfn(IntPtr hWnd, int lParam)
    {
        StringBuilder stbrTitle = new StringBuilder(255);
        int titleLength = GetWindowText(hWnd, stbrTitle, stbrTitle.Capacity + 1);
        string strTitle = stbrTitle.ToString();
        if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
        {
            win_List[i++] = strTitle;                      
        }
        return true;
    }
    public string[] GetWinList()
    {
        EnumDelegate del_fun = new EnumDelegate(lpfn);
        EnumWindows(del_fun, IntPtr.Zero);
        return win_List;
    }
