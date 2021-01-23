    public class ThingThatMovesToTheLeft
    {
        Direction dir = Direction.Left;
        Coord pos = new Coord(0, 0);
        public void Move()
        {
            this.pos = ConvertDirectionToCoord(this.dir) + this.pos;
        }
    }
