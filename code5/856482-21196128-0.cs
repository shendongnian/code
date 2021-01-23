    BinaryFormatter bFormat = new BinaryFormatter();
    Rectangle bounds = new Rectangle();
    Bitmap inImage = bFormat.Deserialize
    (
        stream, 
        headers => 
        {
            foreach(var header in headers)
            {
                if(header.Name == "bounds")
                    bounds = (Rectangle)header.Value;
            }
            return null;
        }
    ) as Bitmap;
