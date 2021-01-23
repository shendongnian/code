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
    Also make `ShowName` virtual, this enables more concrete classes to override it.
    
    class University : CommunityBase<IStudent>
    {
        public University(IStudent member)
            : base(member)
        {
        }
        public override void ShowName()
        {
            Console.WriteLine(_member.FirstName + " " + _member.LastName +
                 " Student-No. = " + _member.StudentNumber);
        }
    }
