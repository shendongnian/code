    // I binded the FlipView with FlipViewImage
    // which is a list of strings (each string being a path)
    private List<string> _flipViewImage;
    public List<string> FlipViewImage
    {
       get { return _flipViewImage; }
       set
       {
          _flipViewImage = value;
          NotifyPropertyChanged("FlipViewImage");
       }
    }
    // Then I fill the list
    FlipViewImage = new List<string>
    {
       // Again replace the image paths with your own
       "../Assets/Seel_photo_Aurelien.png",
       "../Assets/shop_woman.jpg",
       "../Assets/Poster.jpg"
    };
