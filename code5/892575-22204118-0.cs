    public const string TEXT_TAB = "    ";
    
    private void Province_Format(object sender, ListControlConvertEventArgs e)
    {
        string provCode = ((Province)e.ListItem).ProvinceCode;
        string provName = ((Province)e.ListItem).ProvinceName;
        e.Value = provCode + TEXT_TAB + provName;
    }
