    public static class ListViewExtensions {
        public static object FintItemWithText(this ListView lv, string text) {
            foreach (ListViewItem item in lv.Items) {
                if (item.Content.ToString() == text) {
                    return item;
                }
            }
            return null;
        }
    }
