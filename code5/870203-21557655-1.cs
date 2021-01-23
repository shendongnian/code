    class Program
        {
            static void Main(string[] args)
            {
                List<string> resLines = new List<string>();
                var lines  = File.ReadLines("file.csv");
                foreach (var line in lines)
                {
                   
                    //here I suppose that your csv file it like this 
                        // 1,Peter,USA,12345
                        // 2,Anna,UK,45678
                    var res = line.Split(new char[] {','});
                  //or name to search 
                    if (res[1] == "Peter")
                    {                        
                        resLines.Add(res[2]);
                    
                    }
                }
                //to get the output  
                foreach (var line in resLines)
                {
                    Console.WriteLine(line);
                }
    
            }
        }
