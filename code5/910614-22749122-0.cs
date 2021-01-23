        [XmlIgnoreAttribute()] 
    	public Bitmap Picture { get { return picture; } set { picture = value; } } 
    	
    	[XmlElementAttribute("Picture")] 
    	public byte[] PictureByteArray { 
    		get { 
    			if (picture != null) { 
    				using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                         picture.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                         return ms.ToArray();
                    }
    			} else return null; 
    		} 
    		set { 
    			if (value != null) 
                {
    				using (System.IO.MemoryStream ms = new System.IO.MemoryStream(value))
                                    {
                                       picture = new Bitmap(Image.FromStream(ms));
                                    } 
                }
    			else picture = null; 
    		} 
    	}
