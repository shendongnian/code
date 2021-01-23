    internal class Concrete : Base<ChildThing>
    {
        public override IBaseThing<ChildThing> Thing
        {
            get { return ChildThing; }
        }
        public IChildThing ChildThing { get; set; }
    }
