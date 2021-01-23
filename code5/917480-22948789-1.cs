    abstract class CommunityBase<T> where T : IPerson
    {
        protected T _member;
        public T Member { get return _member; }
        public CommunityBase(T member)
        {
            _member = member;
        }
        public virtual void ShowName()
        {
            Console.WriteLine(_member.FirstName + " " + _member.LastName);
        }
    }
