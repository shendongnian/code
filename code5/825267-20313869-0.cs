    public void Update(GameTime gt)
    {
        if (canCheckSpace)
        {
             if (spaceIsPressed())
             {
                  doThings();
             }
        }
        if (jumpHeight > 0)
        {
            canCheckSpace = false;
        }
    }
