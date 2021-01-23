        static Dictionary<string, Dictionary<string, string>> ReadFromFile()
        {
            using (var fs = new FileStream("C:/test.dat", FileMode.OpenOrCreate))
            {
                    var bw = new BinaryFormatter();
                    return (Dictionary<string, Dictionary<string, string>>)bw.Deserialize(fs);
            }
        }
        static void WriteToFile(Dictionary<string, Dictionary<string, string>> dic)
        {
            using (var fs= new FileStream("C:/test.dat", FileMode.OpenOrCreate))
            {
                using (var w = new StreamWriter(fs))
                {
                    var bw = new BinaryFormatter();
                    bw.Serialize(fs, dic);
                    w.Write(dic);
                }
            }
        }
