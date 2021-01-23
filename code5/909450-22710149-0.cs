    Dictionary<Item, List<Tag>> itemTagMap = new Dictionary<Item, List<Tag>>();
    //Iterate through tags and update value for each tag
    List<Tag> tags = itemTagMap[C];
    for(int i=0; i < tags.Count; i++) { /* tags[i]. ... Update here */ } 
    //Query all of the Items that have tagI
    List<Item> results = itemTagMap.Where(kvp => kvp.Value.Contains(Tag_i)).ToList(); //Getting all the items that have Tag_i
