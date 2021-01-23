     class Program
            {
                static void Main(string[] args)
                {
                    List<string> resLines = new List<string>();
                    var lines  = File.ReadLines("file.csv");
                    foreach (var line in lines)
                    {
                        //or name to search 
                        if (line.Contains("Peter"))
                        {
                            //here I suppose that your csv file look like this 
                            // 1,Peter,USA,12345
                             // 2,Anna,UK,45678
                            resLines.Add(line.Split(new char[] {','})[2]);
                        }
                    }
        
                }
            }
