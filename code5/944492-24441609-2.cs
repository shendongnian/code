    public abstract class Enums<Temp> where Temp : class {
        public TEnum DoSomething<TEnum>(string name) where TEnum : struct, Temp
        {
            // Your code
        }
    }
    public abstract class Enums : Enums<Enum>
    { 
    }
