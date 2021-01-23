        public static void Method<TEnum>(TEnum myEnum) 
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum.");
            }
            if ((DependencyLifecycle)myEnum== DependencyLifecycle.SingleInstance)
            {
                //do some thingh
            }
        }  
