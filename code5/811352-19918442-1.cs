    [Serializable]
    public class cEspecie
    {
       //...Snip...
        [XmlIgnore] //Skip this object
        public BitmapImage Imagen
        {
            get { return imagen;  }
            set { imagen = value; }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)] //This creates a secret hidden property that does not show up in intellisense
        [XmlElement("Imagen")] //It uses the name of the real property for it's name
        public BitmapImageSearalizer ImagenSerialized
        {
            get
            {
                return new BitmapImageSearalizer(imagen);
            }
            set
            {
                imagen = value.GetSearalizedImage();
            }
        }
    }
    [Serializable]
    internal BitmapImageSearalizer
    {
        public BitmapImageSearalizer(BitmapImage sourceImage)
        {
            //...Snip...
        }
        public BitmapImage GetSearalizedImage()
        {
            //...Snip...
        }
        //...Snip...
    }
