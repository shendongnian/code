    public class Location
    {
        ...
        your code
        ...
    
        public void Assign(Location aSource)
        {
            x = aSource.x;
            y = aSource.y;
        }
    }
    tile.location.Assign(player.location);
