    public class Base
    {
        private int PrivateProperty { get; set; }
        protected int ProtectedProperty { get; set; }
        public bool PublicProperty { get; private set; }
    }
    public class Derived : Base
    {
        public void A_Method_Which_Need_BaseProperties()
        {
            if (this.PublicProperty) //Derived can access (only Read) Base PublicProperty
            {
                this.ProtectedProperty = 1; //Derived can access (Both Read and Write) Base ProtectedProperty
                //this.PrivateProperty = 2; //You can't do this. Derived can not access Base PrivateProperty
            }
        }
    }
