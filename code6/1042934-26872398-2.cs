    public double Bid
    {
        get { return _bid; }
        set
        {
            BidUp = (value > this.Bid);
            _bid = value;
            OnPropertyChanged("Bid");
            OnPropertyChanged("BidUp"); // notify both properties in the same setter
        }
    }
