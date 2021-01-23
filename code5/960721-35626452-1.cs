    [HubName("ItemHub")]
    public class ItemHub : Hub
    {
          public void GetByteArray(IEnumerable<ImageData> images)
          {
             foreach (var item in images ?? Enumerable.Empty<ImageData>())
             {
                var tokens = item.Image.Split(',');
                if (tokens.Length > 1)
                {
                   byte[] buffer = Convert.FromBase64String(tokens[1]);
                }
              }
          }
    }
    public class ImageData
    {
        public string Description { get; set; }
        public string Filename { get; set; }
        public string Image { get; set; }
    }
