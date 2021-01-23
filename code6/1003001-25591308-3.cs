    public class GroupMember
    {
        private UserGroup _Parent;
        
        public GroupMember(UserGroup parent)
        {
            _Parent = parent;
        }
        public MemberState State { get {return _Parent.GetState(this);} }
        // Where GetState is a function that returns the state from _MemberState
        
        ...
    }
