    bool collided = false;
    for (int i = 0; i < boxlist.Count; i++)
    {
        if (player.collisionRect.Intersects(boxlist[i].collisionRect))
        {
            ground.Y = boxlist[i].collisionRect.Y;
            player.setPositionY(0);
            collided = true;
            //break; //If you want to only handle one collision you can uncomment this
        }
    }
    if (!collided)
        ground.Y = 640;
    
