    public bool ChangeColor {get; set;}
    private double _Bid;
    public double Bid
    {
        get { return _Bid; }
        set
        {
             If (_Bid < value)//, change fore color
                  ChangeColor = True;
            _Bid = value;
            DisplayCurrentPrice = String.Format("{0} / {1}", value, Ask);
        }
    }
