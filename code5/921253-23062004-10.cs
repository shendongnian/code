    class MovingPlatform
    {
        void Update(Tile[] collidableTiles)
        {
            Position += direction;
            //test collision
            bool isCollision = CollisionTest(collidableTiles);
            if (isCollision)
            {
                //undo the movement and change direction
                Position -= direction;
                direction = newDirection;
            }
        }
        //returns true if this platform intersects with any of the specified tiles
        bool CollisionTest(Tile[] tiles)
        {
            foreach (Tile tile in tiles)
                if (IntersectsTile(tile))
                    return true;
            return false;
        }
    }
