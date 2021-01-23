    public class MyInterface : IMyInterface
    {
        object ICloneable.Clone() // explicit interface implementation
        {
            return this.Clone(); // calls the other Clone method
        }
        public IMyInterface Clone()
        {
            return new MyInterface
            {
                // member initializations
            };
        }
    }
