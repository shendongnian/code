    public double Bid
    {
        get { return _bid; }
        set
        {
            BidUp = (value > this.Bid);
            _bid = value;
            OnPropertyChanged(null); // notify change of EVERY property - good if few properties in ViewModel
        }
    }
