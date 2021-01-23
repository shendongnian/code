    public class MyClass<TA, TB> : IMyClass<TA, TB>
    {
        public bool MyMethod(TA argumentX, TB argumentY)
        {
            argumentX = SpecialPreFormatterForTA(argumentX);
            return MyMethodCommon(argumentX, argumentY);
        }
    
        public bool MyMethod(TB argumentX, TA argumentY)
        {
            argumentY = SpecialPreFormatterForTA(argumentY);
            return MyMethodCommon(argumentX, argumentY);
        }
        private bool MyMethodCommon(object argumentX, object argumentY)
        {
            // DO STUFF
        }
    }
