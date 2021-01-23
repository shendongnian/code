    private readonly Image availablePic ;
    private readonly Image unavailablePic ;
    // initialize images in static constructor
    
    public static PictureBox UnavailablePic
    {
       get{
           return new PictureBox {Image = unavailablePic};
       }
    }
    
    public static PictureBox AvailablePic
    {
       get{
           return new PictureBox {Image = availablePic};
       }
    }
