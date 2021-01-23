    private bool IsPanorama(UIElement element)
    {
        bool isPanorama =false;
       try{
           Panorama p = (Panorama)element;
            isPanorama = true;
           return isPanorama ;
          }
          catch(Exception ex)
          {
            isPanorama = false;
            return isPanorama ;
          }
    }
