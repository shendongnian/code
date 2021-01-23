    public override bool Equals(object obj)
    {
        if (obj != null && obj is Point)
        {
	       Point other = (Point)obj;
           if (this.X == other.X && this.Y == other.Y)
           {
               return true;
           }
           return false;
        }
        return false;
    }
