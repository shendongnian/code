    public IScrollInfo Scroller { get; set; }
    bool IScrollInfo.CanHorizontallyScroll
    {
        get { return Scroller.CanHorizontallyScroll; }
        set { Scroller.CanHorizontallyScroll = value; }
    }
