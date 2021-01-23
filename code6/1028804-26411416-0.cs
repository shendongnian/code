    private void SetTinderInPit()
    {
    	var currentMouseState = Mouse.GetState();
    	if (!player.NextToFirePit) return;
    	
    	player.PlayerInventory.Items.Where(item => item.ItemName == "tinder").ToList().ForEach(item =>
    	{
    		allItemsOnGround.Where(x => x.ItemName == "firepit" &&
    			x.ItemRectangle.Contains(MouseWorldPosition) &&
    			currentMouseState.LeftButton == ButtonState.Pressed &&
    			oldMouseState.LeftButton == ButtonState.Released)
    				.ToList().ForEach(pit =>
    				{
    					item.ItemName = "empty";
    					pit.ItemName = "firepitwithtinder";
    					pit.Texture = Content.Load<Texture2D>("firepitwithtinder");
    				});
    	});
    	oldMouseState = currentMouseState;
    }
