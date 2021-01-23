    class Program
    {
        public static void Main()
        {
            var data = new capType { tel = new[] {
               new telType { source = "buffalo", time = 1 }
            } };
            var serializer = new XmlSerializer(typeof(capType));
            using (var stream = new StreamWriter(@"E:\cap_test.xml"))
            {
                serializer.Serialize(stream, data);
            }
        }
    }
