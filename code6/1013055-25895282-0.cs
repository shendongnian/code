    class CircularList<T> : List<T>
            {
                public new T this[int index]
                {
                    get { return base[index%Count]; }
                    set { base[index%Count] = value; }
                }
    
                public T this[T item, int distance]
                {
                    get
                    {
                        var index = IndexOf(item);
                        return this[index + distance];
                    }
                    set
                    {
                        var index = IndexOf(item);
                        this[index + distance] = value;
                    }
                }
            }
