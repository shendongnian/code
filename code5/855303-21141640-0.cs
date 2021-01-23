    db = new ItemsetCollection();
    var itemSet = new Itemset() {item1,item2};
    for (int i = 0; i < list.Items.Count; i++)
    {
        itemSet.Add(list.Items[i].ToString());
    }
    db.Add(itemSet);
