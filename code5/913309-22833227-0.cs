    public Point GrabPoint;
    
    private void GeneralMouseDown(MouseEventArgs e)
    {
        GrabPoint = e.Location;
        this.DoDragDrop(this, DragDropEffects.Move);
    }
