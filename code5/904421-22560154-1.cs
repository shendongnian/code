    class Program
    {
        static void Main(string[] args)
        {
    
            for (int i = 1; i <= 15; i++)
            {
    
                int nodeSize;
                if (i < 5)
                {
                    nodeSize = 100000*i;
                }
                else
                {
                    nodeSize = 1000000 * (i-4);
                }
                    Console.WriteLine("\n\nGenerating XML file of size " + nodeSize + " nodes.");
                    DateTime start = DateTime.Now;
                    Random rand = new Random();
                    string path = @"C:\Users\b-kass\Documents\Projects\XmlDiff\Large.xml";
                    using (StreamWriter outfile = new StreamWriter(path, false))
                    {
                        outfile.Write("<root>\n");
                        int maxNodes = nodeSize;
                        while (maxNodes > 0)
                        {
                            maxNodes -= writeXml(outfile, rand, maxNodes);
                        }
                        outfile.Write("</root>\n");
                    }
                    Console.WriteLine("Random Tree Generate time: " + (DateTime.Now - start));
    
                try
                {
                    start = DateTime.Now;
                    // Read the file and display it line by line.
                    using (System.IO.StreamReader file = new System.IO.StreamReader(path))
                    {
                        while (file.ReadLine() != null)
                        {
                        }
                    }
                    Console.WriteLine("Basic read (" + nodeSize + " nodes): " + (DateTime.Now - start));
    
                }
                catch
                {
                    Console.WriteLine("Basic read failed at " + nodeSize + " nodes");
                }
    
                    try
                    {
                        start = DateTime.Now;
                        var xd = System.Xml.Linq.XDocument.Load(path);
                        Console.WriteLine("XDocument (" + nodeSize + " nodes): " + (DateTime.Now - start));
                    }
                    catch
                    {
                        Console.WriteLine("System.Xml.Linq.XDocument failed at " + nodeSize + " nodes");
                    }
    
                    
                    try
                    {
                        start = DateTime.Now;
                        XmlTextReader reader = new XmlTextReader(path);
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);
                        reader.Close();
                        Console.WriteLine("XmlDocument (" + nodeSize + " nodes): " + (DateTime.Now - start));
                    }
                    catch
                    {
                        Console.WriteLine("XmlDocument failed at " + nodeSize + " nodes");
                    }
                    
            }
            Console.ReadLine();
        }
    
        static int writeXml(StreamWriter outfile, Random rand, int maxNode)
        {
            int mymax = (int)Math.Ceiling(maxNode * rand.NextDouble());
            int count = mymax;
            while (mymax > 0)
            {
                string node = "node" + ((int) Math.Ceiling(15*rand.NextDouble()));
                outfile.Write("\n<" + node + ">");
                if (rand.NextDouble() > 0.5 && mymax > 1) // Have nodes?
                {
                    mymax -= writeXml(outfile, rand, mymax);
                }
                else // have value
                {
                    outfile.Write("Data random data " + rand.Next());
                }
                outfile.Write("</" + node + ">");
                mymax--;
            }
            return count;
        }
    }
