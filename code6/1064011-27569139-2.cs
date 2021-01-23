    using System.IO;
    using System.Linq;
    
    static void Main(string[] args)
    {
         var reader = new StreamReader(File.OpenRead(@"C:\test.ini"));
            List<string> data = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');
                if (values.Contains("REMOVE"))
                    continue;
                
                //
                data.Add(string.Join("\t",values));
    
            }
            //Inside data you have all the lines without the removed. You can rewrite
            //to other file 
    }
