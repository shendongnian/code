    var MMove = new Action<Point>(mousePosition =>
    {
        if (Dragging)
        {
            if (direction != Direction.Vertical)
                container.Left = Math.Max(0, mousePosition.X + container.Left - DragStart.X);
            if (direction != Direction.Horizontal)
                container.Top = Math.Max(0, mousePosition.Y + container.Top - DragStart.Y);
        }
    });
    this.MouseMove += (sender,e) => MMove(e.Location);
    this.Maximized += (sender) => MMove(MousePosition);
    this.Minimized += (sender) => MMove(MousePosition);
