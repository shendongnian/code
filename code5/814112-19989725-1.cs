    public static class Barracks
    {
        public static IBattleUnit Recruit(Type preferredType)
        {
            return (IBattleUnit)typeof(Barracks<>).MakeGenericType(preferredType).GetMethod("Recruit", BindingFlags.Public|BindingFlags.Static).Invoke(null,null);
        }
    }
