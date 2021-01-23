    // Input a list of the objects you want your player to collide with
    // this is a list in case you have multiple object2s you want to check 
    // for collision.
    // An Object2 should have a position, height, and width, yes?
    public void Update(GameTime gameTime, List<Object2> object2List)
    {
        // Ani Test
        up_ani.Update(gameTime);
        down_ani.Update(gameTime);
        left_ani.Update(gameTime);
        right_ani.Update(gameTime);
        position += velocity;
        if (Keyboard.GetState().IsKeyDown(key.MoveUp) && prevState.IsKeyUp(key.MoveDown) &&      prevState.IsKeyUp(key.MoveRight) && prevState.IsKeyUp(key.MoveLeft))
        {
            foreach (Object2 o in object2List)
            {
                if (position.Y <= o.position.Y + o.height)
                {
                    velocity.Y = 0;
                }
                else
                {
                    velocity.Y = -3;
                }
            } 
            currentFace = FacePosition.Up;
        }
        else if (Keyboard.GetState().IsKeyDown(key.MoveDown) && prevState.IsKeyUp(key.MoveUp) &&     prevState.IsKeyUp(key.MoveRight) && prevState.IsKeyUp(key.MoveLeft))
        {
            foreach (Object2 o in object2List)
            {
                if (position.Y + playerWidth >= o.position.Y)
                {
                    velocity.Y = 0;
                }
                else
                {
                    velocity.Y = 3;
                }
            } 
            currentFace = FacePosition.Down;
        }
        else if (Keyboard.GetState().IsKeyDown(key.MoveRight) && prevState.IsKeyUp(key.MoveDown) && prevState.IsKeyUp(key.MoveUp) && prevState.IsKeyUp(key.MoveLeft))
        {
            foreach (Object2 o in object2List)
            {
                if (position.X + playerWidth >= o.position.X)
                {
                    velocity.X = 0;
                }
                else
                {
                    velocity.X = 3;
                }
            } 
            currentFace = FacePosition.Right;
        }
        else if (Keyboard.GetState().IsKeyDown(key.MoveLeft) && prevState.IsKeyUp(key.MoveDown) && prevState.IsKeyUp(key.MoveRight) && prevState.IsKeyUp(key.MoveUp))
        {
            foreach (Object2 o in object2List)
            {
                if (position.X <= o.position.X + o.width)
                {
                    velocity.X = 0;
                }
                else
                {
                    velocity.X = -3;
                }
            } 
            currentFace = FacePosition.Left;
        }
        else
        {
            velocity = Vector2.Zero;
        }
        prevState = Keyboard.GetState();
    }
