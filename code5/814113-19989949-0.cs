    public static class Barracks
    {
        private static readonly IDictionary<Type, Func<IBattleUnit>> FactoryMethods = new Dictionary<Type, Func<IBattleUnit>>();
        public static void Register<T>(Func<IBattleUnit> factory)
        {
            FactoryMethods.Add(typeof(T), factory);
        }
        public static IBattleUnit Recruit<T>()
        {
            return Recruit(typeof (T));
        }
        public static IBattleUnit Recruit(Type type)
        {
            Func<IBattleUnit> createBattleUnit;
            if (FactoryMethods.TryGetValue(type, out createBattleUnit))
            {
                return createBattleUnit();
            }
            throw new ArgumentException();
        }
    }
    public class Swordsman : IBattleUnit
    {
        static Swordsman()
        {
            Barracks.Register<Swordsman>(() => new Swordsman());
        }
    }
