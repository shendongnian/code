    //example of class cwObject 
     public class cwObject{
        public string stringtocompare;
        public object anyotherobject;
        
    }
    //main process
     static void Main(string[] args)
        {
            //List contains string to remove
            List<string> stringtoremove = new List<string>();
            stringtoremove.Add("stringtoremove");
            
            //dummy data for cwObject
            cwObject cw = new cwObject();
            cw.stringtocompare = "stringok";
            cw.anyotherobject = "anything";
            cwObject cw1 = new cwObject();
            cw1.stringtocompare = "stringtoremove";
            cw.anyotherobject = 100;
            //dummy data for dictionary to compare
            Dictionary<int, cwObject> dictcw = new Dictionary<int, cwObject>();
            dictcw.Add(0,cw);
            dictcw.Add(1,cw1);
            //new dictionary for container of results
            Dictionary<int,cwObject> filtereddict = new Dictionary<int,cwObject>();
            cwObject cwtemp = null;
            //start enumerating
            foreach (string str in stringtoremove)
            {
                foreach (KeyValuePair<int, cwObject> entry in dictcw)
                {
                    cwtemp = entry.Value;
                    if (!cwtemp.stringtocompare.Equals(str)) {
                        filtereddict.Add(entry.Key,entry.Value);
                    
                    }
                }
            }
            //output the result
            foreach (KeyValuePair<int, cwObject> entry in filtereddict)
            {
                cwtemp = entry.Value;
                Console.WriteLine(cwtemp.stringtocompare);
            }
            Console.ReadLine();
        }
