    public sealed class InputFormatAttribute : Attribute
    {
        private string _format;
        public string Format
        {
            get { return format; }
        }
        public InputFormatAttribute(string format)
        {
            _format = format;
        }
    }
    [InputFormat("CSV")]
    public class CSVReader : IReader
    {
        // your CSV parsing code here
        public BusinessObject Parse(string file)
        {}
    }
    BusinessObject LoadFile(string fileName)
    {
        BusinessObject result = null;
        DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        FileInfo[] pluginList = dirInfo.GetFiles("*.DLL");
        foreach (FileInfo plugin in pluginList)
        {
            System.Reflection.Assembly assem = System.Reflection.Assembly.LoadFile(fileInfo.FullName);
            Type[] types = assem.GetTypes();
            Type type = types.First(t => t.BaseType == "IReader");
            
            object[] custAttrib = type.GetCustomAttributes(typeof(InputFormatAttribute), false);
            InputFormatAttribute at = (InputFormatAttribute)custAttrib[0];
            if (at.Format.Equals(Path.GetExtension(fileName).Substring(1), StringComparison.CurrentCultureIgnoreCase))
            {
                IReader reader = (IReader)assem.CreateInstance(type.FullName);
                return reader.Parse(fileName);
            }
                
        }
        // got here because not matching plugin found
        return null;
    }
