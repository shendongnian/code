      private ImageSource _smallImage ;
      public ImageSource SmallImage
      {
         get
         {
            return _smallImage;
         }
         set
         {
            if (_smallImage.Equals(value)) return;
            _smallImage = value;
            NotifyPropertyChanged(() => SmallImage);
         }
      }
