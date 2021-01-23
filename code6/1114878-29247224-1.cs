    private SolidColorBrush rectangleFill;
    public SolidColorBrush RectangleFill
    {
        get{ return rectangleFill;}
        set{ rectangleFill=value;
             NotifyPropertyChanged("RectangleFill");
           }
    }
