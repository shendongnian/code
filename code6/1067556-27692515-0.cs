    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"
            <test>
              <TestDate>1986-01-13T14:50:31Z</TestDate>
              <TestBool>true</TestBool>
              <TestNumber>123</TestNumber>
              <TestStr>test</TestStr>
            </test>";
            XmlSerializer ser = new XmlSerializer(typeof(Test));
            Test test = (Test)ser.Deserialize(new StringReader(xml));
            string json = JsonConvert.SerializeObject(test, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
    [XmlType("test")]
    public class Test
    {
        public string TestStr { get; set; }
        public int TestNumber { get; set; }
        public DateTime TestDate { get; set; }
        public bool TestBool { get; set; }
    }
