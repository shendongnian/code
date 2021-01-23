    bool boosting = false;
    bool coolingDown = false;
    float someIncrement = -1;
    float cooldownTime = 0;
    float timeRequired = 10;
    public void updateMovement()
    {
        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1.0f)
        {
            // Player one has pressed the left thumbstick up.
            Position.X = Position.X - (5 + speedup1);
        }
        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1.0f)
        {
            // Player one has pressed the left thumbstick up.
            Position.X = Position.X + (5 + speedup1);
        }        
        //updates boost speed, then once boostspeed returns to normal,
        //begin to update cooldown time
        if(boosting && speedup1 >= 0)
        { 
            speedup1 -= someIncrement;
            if(speedup1 <= 0)
            {
                speedup1 = 0
                boosting = false;
                coolingDown = true;
            }
        }
        //executes once boost has returned to normal
        //updates time remaining before you can boost again
        if(coolingDown)
        {
            cooldownTime += gameTime.EllapsedMilliseconds;
            if(cooldownTime >= timeRequired)
            {
                coolingDown = false;
                cooldownTime = 0;
            }
        }
        //will not execute until the boost has finished AND cooldown has finished
        if (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0 
            && boosting == false && coolingDown == false)
        {
            speedup1 = 5;
            boosting = true;
        }        
    }
