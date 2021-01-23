    private void SetTinderInPit()
    {
        MouseState currentMouseState = Mouse.GetState();
    
        if (player.NextToFirePit)
        {
            Item tinder = player.PlayerInventory.Items.FirstOrDefault(i => i.ItemName == "tinder");
            if (tinder != null)
            {
                Item firepit = allItemsOnGround.FirstOrDefault(i => i.ItemName == "firepit");
                if (firepit != null && 
                    firepit.ItemRectangle.Contains(MouseWorldPosition) &&
                    currentMouseState.LeftButton == ButtonState.Pressed &&
                    oldMouseState.LeftButton == ButtonState.Released)
                {
                    tinder.ItemName = "empty";
                    firepit.ItemName = "firepitwithtinder";
                    firepit.Texture = Content.Load<Texture2D>("firepitwithtinder");
                }
           }
           oldMouseState = currentMouseState;
        }
    }
