    class MyUrls 
    {
        List<string> _urls = new List<string>();
        public void AddUrl(string url)
        {
            _urls.Add(url);
            if (_urls.Count == 3 && OnFull != null)
                OnFull.Invoke();
        }
        public IEnumerable<string> Urls
        {
            get
            {
                return _urls;
            }
        }
        public event Action OnFull;
    }
