    private void SetTinderInPit()
    {
        MouseState currentMouseState = Mouse.GetState();
    
        if (player.NextToFirePit)
        {
            foreach (Item tinder in player.PlayerInventory.Items.Where(i => i.ItemName == "tinder")
            {
                foreach (Item firepit in allItemsOnGround.Where(i => i.ItemName == "firepit"))
                {
                   if (firepit.ItemRectangle.Contains(MouseWorldPosition) &&
                    currentMouseState.LeftButton == ButtonState.Pressed &&
                    oldMouseState.LeftButton == ButtonState.Released)
                    {
                       tinder.ItemName = "empty";
                       firepit.ItemName = "firepitwithtinder";
                       firepit.Texture = Content.Load<Texture2D>("firepitwithtinder");
                    }
                 }
           }
           oldMouseState = currentMouseState;
        }
    }
