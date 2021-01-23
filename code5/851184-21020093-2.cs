    public class NamedRowHeaderType : RowHeaderType 
    {
    }
    public class RowHeaderType
    {
    }
    public class HeaderDisplayType
    {
        public static NamedRowHeaderType doubleColumn = new NamedRowHeaderType();
        public static NamedRowHeaderType table = new NamedRowHeaderType();
        public static RowHeaderType singleColumn = new RowHeaderType();
    }
    class Sample
    {
        public Worksheet crWsheet<T>(string masterHeading, List<T> list, ExcelCreator.RowHeaderType headerType = null)
        {
            headerType = headerType ?? ExcelCreator.HeaderDisplayType.doubleColumn;
            //method body
            return null;
        }
        public Worksheet crWsheet<T>(string masterHeading, List<T> list, ExcelCreator.NamedRowHeaderType headerType = null, string RowName = "Row1")
        {
            headerType = headerType ?? ExcelCreator.HeaderDisplayType.doubleColumn;
            //method body
            return null;
        }
        static void Main(string[] args)
        {
            Sample s;
            s.crWsheet<string>("", null, ExcelCreator.HeaderDisplayType.singleColumn);
            s.crWsheet<string>("", null, ExcelCreator.HeaderDisplayType.doubleColumn, "Row1");
            s.crWsheet<string>("", null, ExcelCreator.HeaderDisplayType.singleColumn, "Row1"); // compile error
        }
    }
