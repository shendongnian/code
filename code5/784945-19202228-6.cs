    private Vector2 GetCollisionNormal(Rectangle boxBeingIntersected)
    {
        getCorners(boxBeingIntersected);
        bool isAboveAC = isOnUpperSideOfLine(corners["bottomRight"], corners["topLeft"], getBallCenter());
        bool isAboveDB = isOnUpperSideOfLine( corners["topRight"], corners["bottomLeft"], getBallCenter());
        if (isAboveAC)
        {
            if (isAboveDB)
            {
                //top edge has intersected
                return -Vector2.UnitY;
            }
            else
            {
                //right edge intersected
                return Vector2.UnitX;
            }
        }
        else
        {
            if (isAboveDB)
            {
                //left edge has intersected
                return -Vector2.UnitX;
            }
            else
            {
                //bottom edge intersected
                return Vector2.UnitY;
            }
        }
    }
----
    public bool isOnUpperSideOfLine(Vector2 corner1, Vector2 oppositeCorner, Vector2 ballCenter)
    {
        return ((oppositeCorner.X - corner1.X) * (ballCenter.Y - corner1.Y) - (oppositeCorner.Y - corner1.Y) * (ballCenter.X - corner1.X)) > 0;
    }
