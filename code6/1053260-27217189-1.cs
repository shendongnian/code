    List<SomeSprite> Sprites = new List<SomeSprite>();
    
    //add items to the collection
    
    for (int i = 0; i < Sprites.Count; ++i)
    {
      SomeSprite Sprite = Sprites[i];
      if (SomeCondition == true) //determine if the sprite collided here
      {
        Sprites.RemoveAt(i);
      }
    }
