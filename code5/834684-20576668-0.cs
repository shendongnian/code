    public class ConcreteObject1 : AbstractObject
    {
        public override List<SomeObject> GetObjects()
        {
            return new List<SomeObject>();
        }
    }
    public class ConcreteObject2 : AbstractObject
    {
        public override List<SomeObject> GetObjects()
        {
            //do some other stuff
            return new List<SomeObject>();
        }
    }
