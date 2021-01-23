    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    
    namespace MemoryHog
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("    Total Memory To Eat Up in Megs: " + args[0]);
                Console.WriteLine("Millisecs Pause Between Increments: " + args[1]);            
                int memoryTotalInMegaBytes     = Convert.ToInt32(args[0]);
                int secondsToPause             = Convert.ToInt32(args[1]);
                Console.WriteLine("Memory Usage:" +     Convert.ToString(GC.GetTotalMemory(false)));
                long runningTotal = GC.GetTotalMemory(false);
                long endingMemoryLimit = Convert.ToInt64(memoryTotalInMegaBytes) * 1000 *     1000;
                List<XmlNode> memList = new List<XmlNode>();
                while (runningTotal <= endingMemoryLimit)
                {
                    XmlDocument doc = new XmlDocument();
                    for (int i=0; i < 1000000; i++)
                    {
                        XmlNode x = doc.CreateNode(XmlNodeType.Element, "hello", "");
                        memList.Add(x);
                    }
                    runningTotal = GC.GetTotalMemory(false);
                    Console.WriteLine("Memory Usage:" +     Convert.ToString(GC.GetTotalMemory(false)));
                    Thread.Sleep(secondsToPause);
                }
                Console.ReadLine();
                
            }
    
        }
    }
