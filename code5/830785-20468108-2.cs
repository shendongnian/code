    internal class Concrete : Base<IChildThing>
    {
        public override IChildThing Thing
        {
            get
            {
                return GetChildThing();
            }
         }
    }
