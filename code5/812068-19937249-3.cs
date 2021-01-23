    [DataContract]
    class Foo
    {
        private bool _isDeleted;
    
        public bool IsDeleted 
        { 
           get { return _isDeleted; }
           set {  } 
        }
        internal void SetIsDeletedInternal(bool value)
        {
            _isDeleted = value;
        }
    }
