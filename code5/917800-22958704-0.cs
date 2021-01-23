    class NotifyOnCountList<T> : List<T>
    {
        int _count;
        Action _callback;
        public NotifyOnCountList(int count, Action callback)
        {
            _count = count;
            _callback = callback;
        }
        public new void Add(T item)
        {
            base.Add(item);
            if (_count == Count && _callback != null)
                _callback();
        }
    }
    void Func()
    {
        NotifyOnCountList<string> Url = new NotifyOnCountList<string>(3, fullList);
        Url.Add("www.1.com");
        Url.Add("www.2.com");
        Url.Add("www.3.com");
    }
    void fullList()
    {
        int a = 1;
    }
