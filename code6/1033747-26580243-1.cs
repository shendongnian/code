     class Program
        {
            static void Main(string[] args)
            {
                ReadTextToDictionary read = new ReadTextToDictionary();
                var strings = read.TextToListString(@"C:\stackoverflow\first.txt");
                var dictionarys = read.TextToDictionaryString(@"C:\stackoverflow\second.txt");
                foreach(var s in strings) {
                    var compare = dictionarys.Where(a=>a.Value.Contains(s.ToString()));
                    foreach(var f in compare)
                    {
                        Console.WriteLine(s+" in line "+f.Key.ToString() + " " + f.Value);
                    }
                }
                Console.ReadKey();
            }
        }
        class ReadTextToDictionary
        {
            public List<string> TextToListString(string path){
               
                var lines =  System.IO.File.ReadAllLines(path);
                return lines.ToList();
            }
            public Dictionary<int,string> TextToDictionaryString(string path)
            {
                Dictionary<int, string> dstr = new Dictionary<int, string>();
                var lines = System.IO.File.ReadAllLines(path);
                int count = 0;
                foreach (var s in lines)
                {
                    count++;
                    dstr.Add(count, s);
                }
                return dstr;
            }
        }
