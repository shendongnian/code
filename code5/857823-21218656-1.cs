    private ImageFileViewModel imageFileName;
    public ImageFileViewModel ImageFileName
    {
       get
       {
          return imageFileName;
       }
       set
       {
          if(imageFileName != value)
          {
             imageFileName = value;
             OnPropertyChanged("ImageFileName");
          }
       }
    }
