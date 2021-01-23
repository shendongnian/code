    public List<Image> GetImages(int count)
    {
        var result = new List<Image>();
    
        for(int i=0; i<count; i++)
        {
            //create/draw/load your image
            var image = new Image(100, 100);
            result.Add(image);
        }
        return result;
    }
    static void Main()
    {
        var images = GetImages(4);
        foreach(var image in images)
        {
            //do something with image
        }
    }
