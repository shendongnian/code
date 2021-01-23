       public IEnumerator<Raflle> GetEnumerator()
            {
                return TList.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
