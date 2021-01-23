    internal static void grayOut2(ref ListViewItem item)
    {
        //change each selected item to gray text
        //currently, multiselect is turned off, so this will only be one item at a time
        item.UseItemStyleForSubItems = false;
        item.ForeColor = Color.Gray;
        item.Font = new Font("MS Sans Serif", 10, FontStyle.Italic);
        item.Selected = false;
    }
