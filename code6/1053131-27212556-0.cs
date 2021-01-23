    public Texture(SerializationInfo info, StreamingContext context)
    {
        Bitmap = (Bitmap)info.GetValue("Bitmap", typeof(Bitmap));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Bitmap", Bitmap);   
    }
