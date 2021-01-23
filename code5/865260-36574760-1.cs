    public class LockContainer
    {
        private BlockingCollection<object> lockItems { get; set; }
        private object LocalLockItem { get; set; }
        public LockContainer()
        {
            lockItems = new BlockingCollection<object>();
            LocalLockItem = new object();
        }
        public object GetLockItem(string str)
        {
            lock (LocalLockItem)
            {
                if (!lockItems.Any(li => (string)li == str))
                {
                    lockItems.Add(str);
                }
                return lockItems.First(li => (string)li == str);
            }
        }
    }
