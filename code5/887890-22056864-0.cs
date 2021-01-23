    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            // Read in every line in the file.
            List<string> myListCollection = new List<string>();
            myListCollection.Add("hi");
            myListCollection.Add("aa");
            myListCollection.Add("hi");
            myListCollection.Add("hello");
            myListCollection.Add("hello");
            Dictionary<string,int> dtCollection  = new Dictionary<string,int>();
            List<string> myDups = new List<string>();
    
            foreach (string y in myListCollection)
            {
                if(dtCollection.ContainsKey(y))
                {
                                Console.WriteLine(y);
    
                }else{
                    dtCollection.Add(y,1);
                }
            }
        }
    }
