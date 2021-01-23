    static void Main(string[] args)
        {
            Decimal result;
            string[] splitchar = new string[]{" "};
            
            using(StreamReader reader = new StreamReader(@"C:\Users\Dell\Desktop\input.txt"))
            {
                while(!reader.EndOfStream)
                {
                    string[] splittedArray = reader.ReadLine().Split(splitchar,                      StringSplitOptions.RemoveEmptyEntries).Where(x => Decimal.TryParse(x, out result)).ToArray();
                    
                    // put your code here to get insert the values in datagrid
                }
            }
           
        }
