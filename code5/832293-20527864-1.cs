    int nextPosX = currRect.X + (int)movementVector.X;
    int nextPosY = currRect.Y + (int)movementVector.Y;
    
    // find out where the rectangle would be after this update:
    Rectangle nextStepsCollisionRect = new Rectangle(nextPosX, nextPosY, width, height);
    
    // check if the test rectangle would collide:
    if( collisionTest(nextStepsCollisionRect, sideWall) )
    {
        // do not move the intended way!
        // invert X and recalc with pre-calculated rectangle again...
    } else {
        // no collision. now move the caculated way:
        ball.CollisionRectangle = nextStepsCollisionRect;
    }
