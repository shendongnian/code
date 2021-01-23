    public static string GetListBoxSelectedItem()
    {
        if (Animallst.SelectedItem != null) //Animallst is the listbox
        {
            return Animallst.SelectedItem.ToString();
        }
        else { return string.Empty(); }
    }
