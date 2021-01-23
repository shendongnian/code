    public override bool Equals(object obj)
    {
        Point other = obj as Point;
    
        if (ReferenceEquals(other, null))
            return false;
        return (this.X == other.X && this.Y == other.Y);
    }
       
