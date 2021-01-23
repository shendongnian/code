    internal class Concrete : Base<IChildThing>
    {
        public override T Thing
        {
            get
            {
                return GetChildThing();
            }
         }
    }
