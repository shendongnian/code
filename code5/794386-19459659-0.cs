    public bool[] ButtonEnabled
    {
        get { return this._liveImage.LSMChannelEnable[2]; }
        set { this._liveImage.LSMChannelEnable[2] = value;
             OnPropertyChanged("ButtonEnabled");
        }
    }
