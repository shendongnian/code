    private void FindControls<T>( List<T> list, Control parent ) where T : Control
    {
        foreach( Control c in parent.Controls )
        {
            if( c is T )
                list.Add( (T)c );
            FindControls( list, c );
        }
    }
    // and use like so:
    var list = new List<Button>();
    FindControls( list, this );
    foreach( var b in list )
        b.Parent.Controls.Remove( b );
