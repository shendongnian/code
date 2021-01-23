     #region Base Abstract Class
    public abstract class EnumBaseType<T> where T : EnumBaseType<T>
    {
        protected static List<T> enumValues = new List<T>();
        public readonly string Key;
        public readonly int Value;
        public readonly int Diameter;
        public EnumBaseType(string key, int value, int diameter)
        {
            Key = key;
            Value = value;
            Diameter = diameter;
            enumValues.Add((T)this);
        }
        protected static System.Collections.ObjectModel.ReadOnlyCollection<T> GetBaseValues()
        {
            return enumValues.AsReadOnly();
        }
        protected static T GetBaseByKey(string key)
        {
            foreach (T t in enumValues)
            {
                if (t.Key == key) return t;
            }
            return null;
        }
    }
    #endregion
    #region Enhanced Enum Sample
    public class MoneyType : EnumBaseType<MoneyType>
    {
        public static readonly MoneyType Cent = new MoneyType("Cent", 1, 19);
        public static readonly MoneyType Nickel = new MoneyType("Nickel", 5, 25);
        public static readonly MoneyType Dime = new MoneyType("Dime", 10, 30);
        public static readonly MoneyType QuarterDollar = new MoneyType("QuarterDollar", 25, 15);
        public static readonly MoneyType HalfDollar = new MoneyType("HalfDollar", 50, 100);
        public static readonly MoneyType Dollar = new MoneyType("Dollar", 100, 29);
        public MoneyType(string key, int value, int diameter)
            : base(key, value, diameter)
        {
        }
        public static ReadOnlyCollection<MoneyType> GetValues()
        {
            return GetBaseValues();
        }
        public static MoneyType GetByKey(string key)
        {
            return GetBaseByKey(key);
        }
    }
    #endregion
    public class Test
    {
        public Test()
        {
            foreach (MoneyType rating in MoneyType.GetValues())
            {
                Console.Out.WriteLine("Key:{0} Value:{1}", rating.Key, rating.Value);
                if (rating == MoneyType.Dollar)
                {
                    Console.Out.WriteLine("This is a dollar!");
                }
            }
            foreach (MoneyType rating in MoneyType.GetValues())
            {
                if (rating.Diameter == MoneyType.Nickel.Diameter)
                {
                    Console.Out.WriteLine("This is a Nickel diameter!");
                }
            }
        }
    }
