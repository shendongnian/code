    class Program
    {
        static void Main(string[] args)
        {
            var crazyValue = CrazyEnum.craZyValue1;
            var resonableValue = crazyValue.ToRreasonableString();
        }
    }
    
    enum CrazyEnum
    {
        craZyValue1,
        CrazYvalUe2
    }
    
    static class CrazyEnumMap
    {
        private static Dictionary<CrazyEnum, string> resonableStrings = new Dictionary<CrazyEnum, string>
        {
            { CrazyEnum.craZyValue1, "Hallo world!" },
            { CrazyEnum.CrazYvalUe2, "Hallo enum!" }
        };
    
        public static string ToRreasonableString(this CrazyEnum value)
        {
            return resonableStrings[value];
        }
    }
