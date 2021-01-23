    interface IOwner
    {
        void Delete(ChildViewModel vm);
    }
    class ChildViewModel
    {
        private IOwner owner;
        public ChildViewModel(IOwner owner)
        {
            this.owner = owner;
        }
        public Delete()
        {
            owner.Delete(this);
        }
    }
    class ParentViewModel:IOwner
    {
        public Delete(ChildViewModel child)
        {
             //deletion logic
        }
    }
