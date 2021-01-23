    public void Fill()
    {
        clssMenu_List lst = new clssMenu_List();
        clssMenu_List.main.AddRange(GetMenuItemsFromForm(mainForm));
        clssMenu_List.accountancy.AddRange(GetMenuItemsFromForm(accountancyForm));
        clssMenu_List.management.AddRange(GetMenuItemsFromForm(managementForm));
    }
