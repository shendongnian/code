    class MyClass<TEnum> where TEnum : struct
    {
        public IEnumerable<TEnum> Roles { get; protected set; }
    
        public MyClass()
        {
            IEnumerable<string> roles = ... ;
    
            
            Roles = GetValues();   // <---- ERROR HERE!
        }
    
        public static IEnumerable<TEnum> GetValues(IEnumerable<String> roles)
        {       
            TEnum value; 
            String[] roleArray = roles.ToArray(); // To avoid the foreach loop.
            
            // What if roleArray.Length == 0?
            for(int i = 0; i < roleArray.Length; i++)
            {
                 // We will never get here
                 if (Enum.TryParse(roleArray[i], out value))
                     yield return value;
            }
        }
    }
