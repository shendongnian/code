    var p = new PagedItemList<int>();
    var sc = new SomeClass();
    sc.SetupWithPagedList(p);
    p.RaisPageChanged(5);
...
 
    
    public class PagedItemList<T>
    {
        public delegate void PageChanged(int newPage);
        public event PageChanged PageChangedEvent;
        public void RaisPageChanged(int page)
        {
            if (PageChangedEvent != null)
                PageChangedEvent(page);
        }
    }
    public class SomeClass
    {
        public void SetupWithPagedList<T>(PagedItemList<T> list)
        {
            list.PageChangedEvent += new PagedItemList<T>.PageChanged(NotifyPageChanged);
        }
        public void NotifyPageChanged(int newPage)
        {
            Debug.WriteLine("Page: ",newPage);
        }
    }
