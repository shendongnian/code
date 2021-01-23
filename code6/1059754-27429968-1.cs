    outfile.MyWriteLines(infile.MyReadLines().Skip(1));
---
    public static class Extensions
    {
        public static IEnumerable<string> MyReadLines(this FileStream f)
        {
            var sr = new StreamReader(f);
            
            var line = sr.ReadLine();
            while (line != null)
            {
                yield return line;
                line = sr.ReadLine();
            }
        }
        public static void MyWriteLines(this FileStream f, IEnumerable<string> lines)
        {
            var sw = new StreamWriter(f);
            foreach(var line in lines)
            {
                sw.WriteLine(line);
            }
        }
    }
