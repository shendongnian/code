    [XmlIgnore]
    public Bitmap UpToDate
    {
        get
        {
            //Only null if file entered is invalid. This causes image to be blank
            if (UpToDateString == null) 
                return null;
            
            //Translates from the resource specified to the bitmap object being used
            var resourceObject = Resources.ResourceManager.GetObject(UpToDateString);
            return (Bitmap) resourceObject;
        }
    }
    //This holds the reference for which resource image to use
    [XmlElement("UpToDate")]
    public string UpToDateString { get; set; }
