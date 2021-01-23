        /// <summary>
        /// 1 bit per pixel bitmap to use as the image source.
        /// </summary>
        [XmlIgnore]
        public Bitmap BitmapImage
        {
            get { return _Bitmap; }
            set
            {
                if (value.PixelFormat != System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
                    throw new FormatException("Bitmap Must be in PixelFormat.Format1bppIndexed");
                _Bitmap = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("Bitmap")]
        public byte[] BitmapSerialized
        {
            get
            { // serialize
                if (BitmapImage == null) return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapImage.Save(ms, ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }
            set
            { // deserialize
                if (value == null)
                {
                    BitmapImage = null;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream(value))
                    {
                        BitmapImage = new Bitmap(ms);
                    }
                }
            }
        }
