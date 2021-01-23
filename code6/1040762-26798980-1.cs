    public float Deg
    {
        get
        {
            return _deg;
        }
        set
        {
            _deg = value;
            this.RotationAngle = new Angle(value, _rad);
        }
    }
    public Angle RotationAngle
    {
        get;
        set;
    }
