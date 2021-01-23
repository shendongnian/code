    public static void UpdateListboxWithStrings(
        ListControl listcontrol, 
        IEnumerable<string> stringlist)
    {
        ListControlItems items;
        if (listcontrol is ListBox)
        {
            items = new ListBoxControlItems(((ListBox)listcontrol).Items);
        }
        else if (listcontrol is ComboBox)
        {
            items = new ComboBoxControlItems(((ComboBox)listcontrol).Items);
        }
        else
        {
            //// Wrong control type.
            //// EARLY EXIT
            return;
        }
        int itemscount = items.Count;
        /// More code here...
    }
