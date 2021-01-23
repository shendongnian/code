    [...]
    int index = sweepline.IndexOf(nl);
    if( index < sweepline.Count-1 )
    {
        Line2D above = sweepline[index + 1];
        if (above.intersectsLine(nl))
        {
            return false;
        }
    }
    [...]
