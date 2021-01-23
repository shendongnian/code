     static void Main(string[] args)
            {
    
                Task<int> t = new Task<int>(() => { return 43; });
                t.Start();
                Task<int> t2 = t.ContinueWith<int>((i) => { return i.Result * 2; });
    
                Console.WriteLine("i = {0}", t2.Result.ToString());
    
                Console.Read();
    
            }
