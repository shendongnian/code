        public static void Query(XElement parameters)
        {
            Console.WriteLine("Readout all velocity-parameters:\n");
            var resultList = new List<string>();
            resultList = ReadoutVelocities(parameters);
            if (resultList.Count == 0)
            {
                Console.WriteLine("Empty list");
            }
            for (int i = 0; i < resultList.Count/2; i++)
            {
                Console.WriteLine("Name: " + resultList.ElementAt(i));
                Console.WriteLine("DefaultValue: " + resultList.ElementAt(i + 1) + "\n");
            }
            Console.WriteLine("\n- - - - - End-Of-Line- - - - - \n");
        }
        public static List<string> ReadoutVelocities(XElement parameters)
        {
            var velocitiesList = new List<string>();
            IEnumerable<XElement> velocity = parameters.Descendants("Velocities");
            foreach (XElement p in velocity.Elements("Axis"))
            {
                velocitiesList.Add(p.Element("Name").Value);
                velocitiesList.Add(p.Element("DefaultValue").Value);
            }
            return velocitiesList;
        }
