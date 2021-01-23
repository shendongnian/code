    class AuthorUpdatedComparer : IEqualityComparer<Author>
    {
        public bool Equals(Author x, Author y)
        {
            return x.Age == y.Age;
        }
    
        public int GetHashCode(Author obj)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(obj, null)) return 0;
    
            return obj.Age.GetHashCode();
        }
    }
