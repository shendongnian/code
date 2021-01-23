    // item is the item you want to edit.
    // tags are the tags that should be associated with this item.
    // dictionary is the dictionary, in which you keep all these associations.
    public void EditItem(string item, 
                         IEnumerable<string> tags, 
                         IDictionary<string, IEnumerable<string>> dictionary)()
    {
        // Get the tags in the given dictionary that associated with the given item.
        IEnumerable<string> tagsContainingItem = dictionary.Where(x=>x.Value.Contains(item))
                                                           .Select(x=x.Key);
        // Get the tags that shouldn't more associated with the item.
        IEnumerable<string> noCommonTags = tagsContainingItems.Except(tags);
        // Delete the item from the lists of the tags that should not be associated with the item.
        foreach(var tag in noCommonTags)
            dictionary[tag].Value.Remove(item);
        // Add the item to the new lists of the tags that are associated with the item.
        foreach(var tag in tags)
            dictionary[tag].Value.Add(item);
    }
