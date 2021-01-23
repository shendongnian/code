    private class StructuralTupleComparer<T>: IEqualityComparer<Tuple<T, T>>{
    
        private IEqualityComparer<T> _cmp;
    
        public StructuralTupleComparer(IEqualityComparer<T> cmp){
          this._cmp = cmp
        }
    
        public bool Equals(Tuple<T, T> t1, Tuple<T, T> t2)
        {
          return _cmp(t1.Item1, t2.Item1) && _cmp(t1.Item2, t2.Item2);
        }
    
    
        public int GetHashCode(Tuple<T, T> t)
        {
          return _cmp.GetHashCode(t.Item1) ^ _cmp.GetHashCode(t.Item2)
        }
    }
