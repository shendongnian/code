    [...]
    try 
    {
        Line2D above = sweepline.Successor(nl);
        if (above.intersectsLine(nl))
        {
            return false;
        }
    }
    catch (NoSuchItemException ignore) { }
    [...]
