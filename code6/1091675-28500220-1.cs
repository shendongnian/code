    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace Demo
    {
        public class Coordinate
        {
            public string DateTime { get; set; }
            public string BeaconID { get; set; }
            public string XCoordinate { get; set; }
            public string YCoordinate { get; set; }
        }
        public static class Program
        {
            public static void Main()
            {
                var date = DateTime.Now.ToString();
                string filename = "D:\\TMP\\TEST.XML";
                List<Coordinate> coords;
                // Deserialize the existing list or create an empty one if none exists yet.
                if (File.Exists(filename))
                    coords = DeserializeFromFile<List<Coordinate>>(filename);
                else
                    coords = new List<Coordinate>();
                // Add some new items to the list.
                int n = coords.Count;
                for (int i = 0; i < 5; ++i)
                {
                    int j = n + i;
                    coords.Add(new Coordinate
                    {
                        DateTime    = date,
                        BeaconID    = "ID" + j,
                        XCoordinate = "X" + j,
                        YCoordinate = "Y" +j
                    });
                }
                // Print the BeaconID of the last item in the list.
                Console.WriteLine(coords[coords.Count-1].BeaconID);
                // Save the amended list.
                SerializeToFile(coords, filename);
            }
            public static void SerializeToFile<T>(T item, string xmlFileName)
            {
                using (FileStream stream = new FileStream(xmlFileName, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, item);
                }
            }
            public static T DeserializeFromFile<T>(string xmlFileName) where T: class
            {
                using (FileStream stream = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(stream) as T;
                }
            }
        }
    }
