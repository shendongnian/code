    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[] {
                "Col_Title_1|Col_Title_2|Col_Title_3|Col_Title_4|Col_Title_5", //Line 0 is Header/Columns
                "Value_1|Value_2|Value_3|Value_4|Value_5" //Line 1 and so on is data records
            };
            string fileContent = "Col_Title_1|Col_Title_2|Col_Title_3|Col_Title_4|Col_Title_5" + Environment.NewLine +
                          "Value_1|Value_2|Value_3|Value_4|Value_5";
            CSVTable table = new CSVTable(lines);
            string firstColumnvalue = table[0]["Col_Title_1"];
            Console.WriteLine(firstColumnvalue);
            table = new CSVTable(fileContent);
            firstColumnvalue = table[0]["Col_Title_1"];
            Console.WriteLine(firstColumnvalue);
        }
    }
    public class CSVTable
    {
        public CSVTable(string table)
            : this(table.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
        {
        }
        public CSVTable(string[] lines)
        {
            Columns = lines[0].Split('|');
            Records = lines.ToList().GetRange(1, lines.Length - 1).Select(line => new CSVRecord(line, Columns)).ToList();
        }
        public string[] Columns { get; private set; }
        List<CSVRecord> Records { get; set; }
        public CSVRecord this[int index]
        {
            get { return Records[index]; }
        }
    }
    public class CSVRecord : Dictionary<string, string>
    {
        public CSVRecord(string line, string[] keys)
            : base()
        {
            var lista = line.Split('|');
            for (int i = 0; i < lista.Length; i++)
            {
                Add(keys[i], lista[i]);
            }
        }
    }
