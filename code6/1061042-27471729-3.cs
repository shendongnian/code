    class Test<T> where T : IShallowClonable<T>
    {
        private List<T> _listCopy;
        public Constructor(List<T> inputList)
        {
            _listCopy = new List<T>(inputList.Count);
            foreach(T obj in inputList) {
                _listCopy.Add(obj.ShallowClone());
            }
        }
        private void MakeChangesInListCopy()
        {
            foreach(T obj in _listCopy) {
                obj.ApplyChange((); // You'll need T to implement another interface or
                                    // to inherit from another class for this to work.
            }
        }
    }
