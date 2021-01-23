    private byte r = 127, g = 127, b = 127;
    public byte R
    {
        get { return r; }
        set { r = value; Color = Color.FromArgb((byte)255, R, G, B); NotifyPropertyChanged("R"); }
    }
    public byte G
    {
        get { return g; }
        set { g = value; Color = Color.FromArgb((byte)255, R, G, B); NotifyPropertyChanged("G"); }
    }
    public byte B
    {
        get { return b; }
        set { b = value; Color = Color.FromArgb((byte)255, R, G, B); NotifyPropertyChanged("B"); }
    }
    private Color color = Colors.Black;
    public Color Color
    {
        get { return color; }
        set { color = value; NotifyPropertyChanged("Color"); }
    }
