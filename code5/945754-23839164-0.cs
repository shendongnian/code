    public class ClassA : AbstractClass<ClassA, Something>
    {
        public override ClassA Clone()
        {
            return this;
        }
    }
