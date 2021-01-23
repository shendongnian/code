    internal class Concrete : Base<ChildThing>
    {
        private IChildThing childThing;
        public Concrete()
        {
            childThing = MakeChildThing();
        }
        public override IBaseThing<ChildThing> Thing
        {
            get { return childThing; }
        }
        private void SomePrivateMethod()
        {
            // can refer to childThing here without casting
        }
    }
