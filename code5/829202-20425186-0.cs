    private bool suppress;
    private YesOrNoOptions _yt;
    public YesOrNoOptions YesOrNo
    {
        get
        {
            return _yt;
        }
        set
        {
            if (_yt != value && !suppress)
            {
                _yt = value;
                suppress = true;
                Notify("YesOrNo");
                suppress = false;
            }
        }
    }
