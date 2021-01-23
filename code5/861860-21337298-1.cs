    // in parent project
    class ParentValues
    {
        public virtual int Key1
        {
            get { return 5; }
        }
        public virtual int Key2
        {
            get { return 10; }
        }
    }
    // in child project
    class ChildValues : ParentValues
    {
        public override int Key2
        {
            get
            {
                return 12;
            }
        }
    }
