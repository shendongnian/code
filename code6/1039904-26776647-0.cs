    public static ImageCollection RSImages
    {
       get
       {
          var ic = new ImageCollection();
          ic.Add(RSConsDark);
          ic.Add(RSConsLight);
          //etc
          return ic; 
       }
    }
