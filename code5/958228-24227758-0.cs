     public class EnumBindableAttribute : Attribute
    {
    }
    public enum ListEnum
    {
        [EnumBindable]
        Item1,
        Item2,
        [EnumBindable]
        Item3
    }
