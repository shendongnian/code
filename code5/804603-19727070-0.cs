    public class MyInterface : IMyInterface
    {
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public IMyInterface Clone()
        {
            return new MyInterface
            {
                // member initializations
            };
        }
    }
