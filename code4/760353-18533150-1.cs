    public static IEnumerable<string> CreateHtmlLists(IEnumerable<string> lines)
    {
        ListItem currentItem = null;
        int listDepth = 0;
        foreach (var line in lines)
        {
            ListItem item;
            if (!ListItem.TryParse(line, out item)) {
                yield return line; // not list item, return as is
                continue;
            }
            if (currentItem == null || (currentItem.IsOrdered && !item.IsOrdered))
            {
                yield return "<ul>"; // start new nested list
                listDepth++;
            }
            else if (!currentItem.IsOrdered && item.IsOrdered)
            {
                yield return "</ul>"; // close nested list
                listDepth--;
            }
            yield return item.Html;
            currentItem = item;
        }
        while (listDepth > 0) { // close all parent lists        
            listDepth--;
            yield return "</ul>";
        }
    }
