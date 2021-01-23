    public class RenderViewModel
    {
      public int RenderId { get; set; }
      public string ClientName { get; set; }
      ....
      public IEnumerable<Image> Images { get; set; }
      public string ZipFileName
      {
        get { return (ClientName + "-" + Title + "-" + JobId)
                .Replace(" ", string.Empty); }
      }
    }
