    class Program
    {
        static void Main()
        {
            List<long> list = new List<long>();
    	    list.Add( long.MaxValue );
    	    list.Add( long.MaxValue - 1 );
    	    list.Add( long.MaxValue - 2 );
            
            long sumA = 0, sumB = 0;
            long res1, res2, res3;
            //You should calculate the following dynamically
            long constant = 1753413056;
            
            foreach (long num in list)
            {
                sumA += num / constant;
                sumB += num % constant;
            }
            
            res1 = (sumA / list.Count) * constant;
            res2 = ((sumA % list.Count) * constant) / list.Count;
            res3 = sumB / list.Count;
            
            Console.WriteLine( res1 + res2 + res3 );
        }
    }
