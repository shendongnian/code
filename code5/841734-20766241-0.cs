    public class FilteredCollection : IList<string>, IEnumerable<string>
    {
        private List<string> list = new List<string>();
        public bool Filter { get; set; }
        protected IList<string> Items
        {
            get
            {
                if (Filter)
                {
                    return list.Where(i => i.StartsWith("A")).ToList();
                }
                return list;
            }
        }
        public IEnumerator<string> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int IndexOf(string item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, string item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public string this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        //continue with the rest
    }
