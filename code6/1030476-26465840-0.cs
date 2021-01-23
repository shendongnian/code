        public IEnumerator<KeyValuePair<int, Line>> GetEnumerator()
        {
            Line line = null;
            current = 0;
            while ((line = GetNext()) != null)
                yield return new KeyValuePair<int, Line>(current, line);
        }
        public abstract Line GetNext();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
