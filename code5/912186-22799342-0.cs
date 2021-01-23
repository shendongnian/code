    private double _grip;
    public double grip
    {
        get
        {
            return _grip;
        }
        set
        {
            if (value > 100) { _grip = 100; }
            else if (value < 0) { _grip = 0; }
            else { _grip = value; }
        }
    }
