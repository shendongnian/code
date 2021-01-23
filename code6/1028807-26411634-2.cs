    MouseState currentMouseState = Mouse.GetState();
    // I would get all the conditional checks out of the way up front first
    if (currentMouseState.LeftButton == ButtonState.Pressed &&
        oldMouseState.LeftButton == ButtonState.Released &&
        player.NextToFirePit)
    {
        foreach (var tinderItem in player.PlayerInventory.Items
            .Where(item => item.ItemName == "tinder").ToList())
        {
            foreach (var firePit in allItemsOnGround
                .Where(item => item.ItemName == "firepit" &&
                               item.ItemRectangle.Contains(MouseWorldPosition)).ToList())
            {
                tinderItem.ItemName = "empty"; 
                firePit.ItemName = "firepitwithtinder";
                firePit.Texture = Content.Load<Texture2D>("firepitwithtinder");
            }
        }
    }
    oldMouseState = currentMouseState;
