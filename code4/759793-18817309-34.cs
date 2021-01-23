    int IComparable.CompareTo(Line2D other)
    {
        if( BottomY < other.BottomY )
        {
            return -other.CompareTo(this);
        }
        
        // we're the segment being added to the sweepline
        if( BottomX >= other.X1 && BottomX >= other.X2 )
        {
            return 1;
        }
        if( BottomX <= other.X1 && BottomX <= other.X2 )
        {
            return -1;
        }
        if( other.Y2 == other.Y1 )
        {
            // Scary edge case: horizontal line that we intersect with. Return 0?
            return 0;
        }
        // calculate the X coordinate of the intersection of the other segment
        // with the sweepline
        double redX = other.X1 + 
            (BottomY - other.Y1) * (other.X2 - other.X1) / (other.Y2 - other.Y1);
        return BottomX.CompareTo(redX);
    }
