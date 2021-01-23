    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class MessageType
        {
            public string Id;
            public string Text;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var rand = new Random ();
                // filling a list with random text messages
                List<MessageType> list = new List<MessageType>();
                for (int i = 0; i < 32000; i++)
                { 
                    string txt = rand.NextDouble().ToString();
                    var msg = new MessageType() {Id = i.ToString(), Text = txt };
                    list.Add(msg);
                }
                IList List = (IList)list;
    
                // doing some random searches
                foreach (int some in new int[] { 2, 10, 100, 1000 })
                {
                    var watch1 = new Stopwatch();
                    var watch2 = new Stopwatch();
                    Dictionary<string, MessageType> dict = null;
                    for (int i = 0; i < some; i++)
                    {
                        string id = rand.Next(32000).ToString();
                        watch1.Start();
                        LinearLookup(List, id);
                        watch1.Stop();
    
                        watch2.Start();
                        // fill once
                        if (dict == null)
                        {
                            dict = new Dictionary<string, MessageType>();
                            foreach (object o in List)
                            {
                                var msg = (MessageType)o;
                                dict.Add(msg.Id, msg);
                            }
                        }
                        // lookup 
                        DictionaryLookup(dict, id);
                        watch2.Stop();
                    }
    
                    Console.WriteLine(some + " x LinearLookup took " 
                        + watch1.Elapsed.TotalSeconds + "s");
                    Console.WriteLine("Dictionary fill and " + some 
                        + " x DictionaryLookup took " 
                        + watch2.Elapsed.TotalSeconds + "s");
                }
            }
    
            static string LinearLookup(IList List, string id)
            {
                foreach (object myObj in List)
                {
                    if (((MessageType)myObj).Id == id)
                    {
                        return ((MessageType)myObj).Text;
                    }
                }
                throw new Exception();
            }
    
            static string DictionaryLookup(Dictionary<string, MessageType> dict,
                string id)
            {
                return dict[id].Text;
            }
        }
    }
