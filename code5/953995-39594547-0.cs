    private int getcolumn()
    {
        Point mousePosition = base.PointToClient(Control.MousePosition);
        switch(mousePosition.Y)
        {
            case mousePosition.Y >= 0 && mousePosition.Y <= base.Columns(0).Width:
                Return base.Columns(0).index
                break;
            case mousePosition.Y >= base.Columns(0).Width && mousePosition.Y <= base.Columns(1).Width:
                Return base.Columns(1).index
                break;
            case mousePosition.Y >= base.Columns(0).Width + base.Columns(1).Width && mousePosition.Y <= base.Columns(2).Width:
                Return base.Columns(2).index
                break;
            default:
                Return -1
        }
    
    }
