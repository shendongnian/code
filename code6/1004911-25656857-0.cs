    public void Move(int width, int height)
        {
            if ((position.X >= 0) && (position.X + size <= width)) //Within X Bounds
            {
                position.X -= XBounce * speed;
            }
            else
            {
                XBounce = -XBounce;
                position.X -= XBounce * size / 2;
            }
            if ((position.Y >= 0) && (position.Y + size <= height)) //Within Y Bounds
            {
                    position.Y -= YBounce * speed;
            }
            else
            {
                YBounce = -YBounce;
                position.Y -= YBounce * size / 2;
            }
        }
