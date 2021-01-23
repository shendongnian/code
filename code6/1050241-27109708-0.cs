            public static void Main(string[] args)
            {
                Insurance i = new Insurance();
                i.company = "State Farm";
                Car c = new Car();
                c.model = "Mustang";
                c.year = "2014";
                c.ins = i;
                XmlSerializer xs = new XmlSerializer(typeof(Car));
                StreamWriter sw = new StreamWriter("Car.xml");
                xs.Serialize(sw, c);
                sw.Close();
            }
            public class Car
            {
                public string model { get; set; }
                public string year { get; set; }
                public Insurance ins {get; set;}
            }
            public class Insurance
            {
                public string company { get; set; }
            }
