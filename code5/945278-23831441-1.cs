    private void ParentControl_MouseDown(object sender, MouseEventArgs e)
    {
        // this is pretty obvious
        _mouseHeldDown = true;
    }
        
    private void ParentControl_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_mouseHeldDown)
            return;
        // get the cursor location in Form-relative coordinates
        var cursor = this.PointToClient(Cursor.Position);
        // only search for pieces if we haven't yet started dragging
        if (_draggedPiece == null)
            FindOverlappingPiece(cursor);
        // if we are currently dragging a piece, update its position
        if (_draggedPiece != null)
            MoveDraggedPiece(cursor);
    }
    private void ParentControl_MouseUp(object sender, MouseEventArgs e)
    {
        // cleanup
        _mouseHeldDown = false;
        _draggedPiece = null;
    }
