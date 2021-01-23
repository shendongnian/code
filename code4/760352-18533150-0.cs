    public class ListItem
    {
        public static bool TryParse(string s, out ListItem item)
        {
            item = null;
            if (!IsListItem(s) && !IsOrderedListItem(s))
                return false;
            item = new ListItem { IsOrdered = IsOrderedListItem(s),
                                  Text = GetItemText(s) };
            return true;
        }
        private static bool IsListItem(string s) {
            return Regex.IsMatch(s, @"^- .*");
        }
        private static bool IsOrderedListItem(string s) {                
            return Regex.IsMatch(s, @"^\d+- .*");
        }
        private static string GetItemText(string s) {
            return s.Substring(s.IndexOf('-') + 1).Trim();
        }
        public bool IsOrdered { get; private set; }
        public int Index { get; private set; }
        public string Text { get; private set; }
        public string Html {
            get { return String.Format("<li>{0}</li>", Text); }
        }
    }
