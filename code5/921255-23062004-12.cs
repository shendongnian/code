    class MovingPlatform
    {
        void Update()
        {
            Position += direction;
            //test collision
            Tile[] tiles = _map.GetNearbyTiles(Position);
            foreach (Tile tile in tiles)
                if (tile.IsSolid)
                    if (IntersectsTile(tile))
                    {
                        //undo the movement and change direction
                        Position -= direction;
                        direction = newDirection;
                        break;
                    }
        }
    }
