    [DataContract]
    class Foo
    {
        [DataMember(Name="IsDeleted")]
        private bool _isDeleted;
    
        public bool IsDeleted 
        { 
           get { return _isDeleted; }
           internal set { _isDeleted = value; } 
        }
    }
