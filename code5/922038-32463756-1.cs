    [Serializable()]
    public class FlatImage
    {
        public Image _image { get; set; }
        public string _key { get; set; }
    }
    void Serialize()
    {
        string path = Options.GetLocalPath("ImageList.bin");
        BinaryFormatter formatter = new BinaryFormatter();
        List<FlatImage> fis = new List<FlatImage>();
        for (int index = 0; index < _smallImageList.Images.Count; index++)
        {
            FlatImage fi = new FlatImage();
            fi._key = _smallImageList.Images.Keys[index];
            fi._image = _smallImageList.Images[index];
            fis.Add(fi);
        }
        
        using (FileStream stream = File.OpenWrite(path))
        {
            formatter.Serialize(stream, fis);
        }
    }
    void Deserialize()
    {
        string path = Options.GetLocalPath("ImageList.bin");
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            using (FileStream stream = File.OpenRead(path))
            {
                List<FlatImage> ilc = formatter.Deserialize(stream) as List<FlatImage>;
                for( int index = 0; index < ilc.Count; index++ )
                {
                    Image i = ilc[index]._image;
                    string key = ilc[index]._key;
                    _smallImageList.Images.Add(key as string, i);
                }
            }
        }
        catch { }
    }
