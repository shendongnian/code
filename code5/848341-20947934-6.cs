    internal class Program
    {
        private static void Main(string[] args)
        {
            List<List<HMData>> data = new List<List<HMData>>();
    
            string[] Ls =
            {
                "L1", "L2", "L3", "L4", "L5", "L6", "L7", "L8", "L9", "L10", "L11", "L12", "L13", "L14",
                "L15", "L16", "L17", "L18", "L19", "L20", "L21", "L22", "L23", "L24", "L25", "L26", "L27", "L28"
            };
            string[] Is =
            {
                "I1", "I2", "I3", "I4", "I5", "I6", "I7", "I8", "I9", "I10", "I11", "I12", "I13", "I14",
                "I15", "I16", "I17", "I18", "I19", "I20", "I21", "I22", "I23", "I24", "I25", "I26", "I27", "I28"
            };
            string[] Bs =
            {
                "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12", "B13", "B14",
                "B15", "B16", "B17", "B18", "B19", "B20", "B21", "B22", "B23", "B24", "B25", "B26", "B27", "B28"
            };
    
            for (int k = 0; k < 4; k++)
            {
                List<HMData> Data_Content = new List<HMData>();
                for (int j = 0; j < 7; j++)
                {
                    var l = Ls.ElementAt((k*7) + j);
                    var i = Is.ElementAt((k*7) + j);
                    var b = Bs.ElementAt((k*7) + j);
    
                    Data_Content.Add(new HMData {x = l, y = i, z = b});
                }
    
                data.Add(Data_Content);
            }
            foreach (var item in data)
            {
                Console.Write("data=[");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("{0},",item[i]);
                }
                Console.WriteLine("{0}]", item[6]);
            }
            Console.ReadLine();
    
        }
    }
    public class HMData
    {
        public string x;
        public string y;
        public string z;
        public override string ToString()
        {
            return string.Format("{{{0},{1},{2}}}", x, y, z);
        }
    }
