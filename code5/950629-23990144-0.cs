      public Bitmap changeByteToImage( Byte[] imagedata )
        {
            System.IO.MemoryStream ms=new System.IO.MemoryStream(imagedata);
            Bitmap picdata=new Bitmap(Image.FromStream(ms));
            return picdata;
        }
