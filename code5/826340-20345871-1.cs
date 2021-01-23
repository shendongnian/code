    class Program
    {      
        static void Main(string[] args)
        {
            string ss = "1,2,3";           
            string search = "2";
            string[] arr = ss.Split(',');
    		
            foreach(string ar in arr)
                {
                if (ar.Equals(search))
                    {
                    Console.WriteLine("true");
                    }
                else
                    {
                    Console.WriteLine("false");
                    }
                }
            
        }
    }
