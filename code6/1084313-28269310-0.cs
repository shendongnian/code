    public void SetPosition(Vector2 newPosition)
    {
        //We remove Size.Height to make the tooltip appear above the mouse, not on top of it
        newPosition = new Vector2(newPosition.X, newPosition.Y - Size.Height);
        string LeavesBoundary = LeavesScreen(new Rectangle((int)newPosition.X, (int)newPosition.Y, (int)this.Size.Width, (int)this.Size.Height));
        if (LeavesBoundary == "top")
        {
            this.Position = new Vector2(newPosition.X, Viewport.Top);
        }
        else if (LeavesBoundary == "right")
        {
            this.Position = new Vector2(Viewport.Right - this.Size.Width, newPosition.Y);
        }
        else if (LeavesBoundary == "topRight")
        {
            this.Position = new Vector2(Viewport.Right - this.Size.Width, Viewport.Top);
        }
        else
            this.Position = newPosition;
    }
