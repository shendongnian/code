     public enum SomeEnum
    {
        Item1,
        Item2,
        Item3
    }
    public static class SomeEnumHelper
    {
        public static SomeEnum[] GetMainItems() 
        {
            return new[] {SomeEnum.Item1, SomeEnum.Item2};
        }
    }
