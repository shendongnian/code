    using System.Resources;
    
    public static Image GetImage(String ImageName)
    {
        Image retImage = null;
        Object o = Properties.Resources.ResourceManager.GetObject(ImageName);
        if (o != null && (o is Image))
        {
            Image img = (Image)((Image)o).Clone();  //necessary to prevent premature disposal
            retImage = img;
        }
        return retImage;
    }
