    class Program
    {
        //Class to store iteration value and time
        class test
        {
            public String Cycle;
            public int Time;
        };
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");            
            List<test> Check = new List<test>();
           
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                // Deatils to fill the list are obtained via XML , which is already sorted.               
                int totsec = (int)TimeSpan.Parse(node.Attributes["ElapsedTime"].Value).TotalSeconds;
                Check.Add(new test() { Cycle = node.Name, Time = totsec });              
            }
           
            // to Find the iteration , Do linear search via Find Function
            int inputtocheck = 130;
            int index = Check.IndexOf(Check.Find(item => item.Time >= inputtocheck ));
            Console.WriteLine(Check[index].Cycle);
           
        }
    }
