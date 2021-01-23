    public  List<FileInfo> _imagesList = new List<FileInfo>();
    public void Main()
    {
       AddImage("YourImagePath1");
       AddImage("YourImagePath2");
       // ...
    }
    public void AddImage(string path)
    {
       _imagesList.Add(new FileInfo(path));
       //var img = Image.FromFile(path); // do this if you need to load your image
    }
