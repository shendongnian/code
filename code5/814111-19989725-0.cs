    public static class Barracks
    {
        public static IBattleUnit Recruit(Type preferedType)
        {
            return (IBattleUnit)typeof(Barracks<>).MakeGenericType(preferedType).GetMethod("Recruit", BindingFlags.Public|BindingFlags.Static).Invoke(null,null);
        }
    }
