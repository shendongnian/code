        public static string ParseListView(string ListViewText)
        {
            var regex = new System.Text.RegularExpressions.Regex("{.*?}");
            var match = regex.Match(ListViewText);
            return match.ToString().TrimStart('{').TrimEnd('}');
        }
