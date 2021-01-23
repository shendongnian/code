    public class Pixel
    {
        public int X;
        public int Y;
        public Pixel(in int x, in int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object pixel)
        {
            Pixel b = pixel as Pixel;
            return X == b.X && Y == b.Y;
        }
		
        public override int GetHashCode()
        {
            //return (a.X << 2) ^ a.Y; // this is also commonly used as a pixel hash code
            return X * 100000 + Y; // a bit hacky [will fail if bitmap width is > 100000]
        }
	}
