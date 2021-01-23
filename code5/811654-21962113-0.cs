    // 2014-02-22 - MPEKALSKI - added property to make possible
                             limiting on zoom on only one axis
    private bool? _zoomX;
    /// <summary>
    /// Property for allowing/disallowing for zoom along X axis. By default allowed (true).
    /// </summary>
    public bool zoomX
    {
        get { return _zoomX ?? true; }
        set { _zoomX = value; }
    }
    private bool? _zoomY;
    /// <summary>
    /// Property for allowing/disallowing for zoom along Y axis. By default allowed (true).
    /// </summary>
    public bool zoomY
    {
        get { return _zoomY ?? true; }
        set { _zoomY = value; }
    }     
