        [Serializable]
        public class MyData
        {
            public int id { get; set; }
            public string data { get; set; }
        }
        static void Main(string[] args)
        {
            string fileName = string.Format("xmlFile_{0}.xml", DateTime.Now.ToString("dd.mm.ss"));
            int dataLength = 0;
            int limit = 100500;
            List<MyData> list = new List<MyData>();
            for (int i = 0; i <= 1000; i++)
            { 
                Random r = new Random();
                string preparedData = Convert.ToBase64String( 
                    System.Text.Encoding.UTF8.GetBytes(r.Next(int.MaxValue).ToString())
                    );
                MyData mydata = new MyData { id = i, data = preparedData };
                StringWriter stringWriter = new StringWriter();
                XmlDocument xmlDoc = new XmlDocument();
                XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
                XmlSerializer serializer = new XmlSerializer(typeof(MyData));
                serializer.Serialize(xmlWriter, mydata);
                string xmlResult = stringWriter.ToString();
                dataLength += xmlResult.Length;
                if (dataLength <= limit)
                    // insert you write method here
                    File.AppendAllText(fileName, xmlResult);
                else
                { 
                    // create new file or something else you want
                }
                list.Add(mydata);
            }
            
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
