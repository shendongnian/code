    int pos; //Declared at the top of the class
    
    pos = 0;
    for (int x = 0; x < gridsize.X; x++) // x represents column
    {
        for (int y = 0; y < ItemList.Count / gridsize.X; y++) // y represents row
        {
            // In the above (ItemList.count / gridsize.X) = number of rows needed
            ItemList[pos].gridLocation = new Point(x, y);
            pos++;
        }
    }
