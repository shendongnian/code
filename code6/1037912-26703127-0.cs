    private double _re, _im;
    public Complex(double re = 0.0, double im = 0.0)
    {
        _re = re;
        _im = im;
    }
    public double Re
    {
         get { return _re; }
         set { _re = value; }//or just get !
    }
    public double Im
    {
         get { return _re; }
         set { _re = value; }//or just get !
    }
