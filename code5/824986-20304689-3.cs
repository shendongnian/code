    // generate array (optionally move to separate method)
    int itemsCount = 6;
    int[] items = new int[itemsCount]; // consider to use List<int>
    Random random = new Random();
    int item;
 
    for(int i = 0; i < itemsCount; i++)
    {
       do {
          item = random.Next(1, 50);
       } while(Array.IndexOf(item) >= 0);
       items[i] = item;
    }
   
    // display generated items
    listBox1.Items.Clear();
    listBox1.Items.AddRange(items);
