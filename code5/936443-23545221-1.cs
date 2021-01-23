    private int _imageWidth;
    public int imageWidth{
       get{ return _imageWidth; }
       set{ _imageWidth = value; OnPropertyChanged("imageWidth"); }
    }
    
    private int _imageHeight;
    public int imageHeight{
       get{ return _imageHeight; }
       set{ _imageHeight = value; OnPropertyChanged("imageHeight");}
    }
