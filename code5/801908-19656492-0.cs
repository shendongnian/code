    using System;
    namespace ConsoleApplication1
    {
        [Flags]
        public enum FlagEnum
        {
            EnumValue1 = 1,
            EnumValue2 = 2,
            EnumValue3 = 4
        }
        public static class LegacyClass
        {
            public static bool PropA { get; set; }
            public static bool PropB { get; set; }
            public static bool PropC { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                LegacyClass.PropB = true;
                FlagEnum result = LegacyClass.PropA ? FlagEnum.EnumValue1 : 0;
                result |= LegacyClass.PropB ? FlagEnum.EnumValue2 : 0;
                result |= LegacyClass.PropC ? FlagEnum.EnumValue3 : 0;
            }
        }
    }
