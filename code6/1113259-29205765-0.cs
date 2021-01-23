    public class PicAdapter : BaseAdapter<string>
    {
        private List<string> _imageUrls = new List<string>();
        public void AddImage(string uri)
        {
            _imageUrls.Add(uri);
        }
        ...
    }
