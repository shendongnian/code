    public class MyClass<TA, TB> : IMyClass<TA, TB>
    {
        public bool MyMethod(TA argumentX, TB argumentY)
        {
            string argX = SpecialPreFormatterForTA(argumentX);
            string argY = SpecialPreFormatterForTB(argumentY);
            return MyMethodCommon(argX, argY);
        }
    
        public bool MyMethod(TB argumentX, TA argumentY)
        {
            string argX = SpecialPreFormatterForTB(argumentX);
            string argY = SpecialPreFormatterForTA(argumentY);
            return MyMethodCommon(argX, argY);
        }
        private bool MyMethodCommon(string argX, string argY)
        {
            // DO STUFF
        }
    }
