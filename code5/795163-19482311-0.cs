    class IntegersGame
    {
        private List<int> _sourceintegers;
        private List<int> _integers;
        public void Add(List<int> integers)
        {
            _sourceintegers = integers;
            Reset();
        }
        public void Reset()
        {
            _integers = _sourceintegers.Select(p => p).ToList();
            _integers.Sort();
        }
        public int GetFirst()
        {
            int ret = _integers.First();
            _integers.Remove(ret);
            return ret;
        }
        public List<int> GetAll()
        {
            return _integers;
        }
        public void Release(int des)
        {
            if (_sourceintegers.Contains(des))
            {
                _integers.Add(des);
                _integers.Sort();
            }
        }
        public int? Get(int source)
        {
            if(_sourceintegers.Contains(source) && (_integers.Contains(source)){
                return source;
            }else{
                return null;
            }
        }
    }
