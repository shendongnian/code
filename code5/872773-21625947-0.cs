    public static class ListControlExtensions
    {
        public static string GetSelectedItemText(this ListControl list, string separator = ",")
        {
            return string.Join(separator, list.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Text));
        }
    }
