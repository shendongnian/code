    Random rnd = new Random();
    List<int> indexes = new List<int>(items.Count);
        
    for (int i = 0; i < items.Count; i++)
    	indexes.Add(i);
    List<string> selectedItems = new List<string>(10);
    int tmp;
    for(int i = 0; i < 10; i++)
    {
    tmp = rnd.Next(1,10000); //something big
    if(indexes.Count > 0)
    {
    	selectedItems.Add(yourItems[indexes[tmp%indexes.Count]]); 
    	indexes.RemoveAt(tmp%indexes.Count);
    }
    else
    	selectedItems.Add(yourItems[rnd.Next(0,9)]); //you ran out of unique items
    }
