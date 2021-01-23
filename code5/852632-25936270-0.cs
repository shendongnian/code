    // collidable object's Class name = SolidBlock
    SolidBlock newSolidBlock;
    List<SolidBlock> solidBlocksList = new List<SolidBlock>();
    // This will create 10 'solid' objects and adds them all to a list
    // This would preferably go in the Load() function so you can set the positions of
    // the blocks after creating them (after the loop)
    int i = 0;
    while (i < 10)
    {
        newSolidBlock = new SolidBlock(Vector2, position) // Assuming width and height 
                                                          // are set within class
        solidBlocksList.Add(newSolidBlock);
        i++;
    }
    // It doesn't matter how you create them, the important lines here are the creation of a
    // newSolidBlock and then the line adding it to the list of blocks.
    solidBlocksList[0].position = new Vector (20, 50); // < for example this is how you would set
                                                       // a block's position.
