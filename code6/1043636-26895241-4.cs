    //private field needy in full property.
    private Color _BorderColor = Color.Red;  //= Color.Red; for default color...
    [PropertyTab("Data")]
    [Browsable(true)]
    [Category("Extended Properties")]
    [Description("Set TextBox border Color")]
    public Color BorderColor
    {
        get {return _BorderColor ;}
        set
        {
            _BorderColor = value;
            Invalidate(); //refresh, trigger new paint.
        }
    }
