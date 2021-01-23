    private Vector2 getBallCenter()
    {
        return new Vector2(circleRect.Location.X + circleRect.Width / 2, circleRect.Location.Y + circleRect.Height / 2);
    }
--
    private void getCorners(Rectangle boxToGetFrom)
    {
        corners.Clear();
        Vector2 tl = new Vector2(boxToGetFrom.X, boxToGetFrom.Y);
        Vector2 tr = new Vector2(boxToGetFrom.X + boxToGetFrom.Width, boxToGetFrom.Y);
        Vector2 br = new Vector2(boxToGetFrom.X + boxToGetFrom.Width, boxToGetFrom.Y + boxToGetFrom.Height);
        Vector2 bl = new Vector2(boxToGetFrom.X, boxToGetFrom.Y + boxToGetFrom.Height);
        corners.Add("topLeft", tl);
        corners.Add("topRight", tr);
        corners.Add("bottomRight", br);
        corners.Add("bottomLeft", bl);
    }
