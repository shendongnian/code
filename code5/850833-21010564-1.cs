    public void Update(Vector2 pos, InventoryScreen invscreen)
    {
        this.position = pos;
        charRange = new Rectangle((int)position.X, (int)position.Y, 64, 57);
        if (alive && charRange.Intersects(itemRect))
        {
            alive = false;
            invscreen.ItemGot(); 
        }
    }
