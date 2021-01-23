    static void Main(string[] args)
        {
            string[] ints = Console.ReadLine().Split(' ');
            double[] realInts = new Double[ints.Length];
            for (int i = 0; i <= ints.Length; i++)
            {
                double val;
                if (Double.TryParse(ints[i], out val))
                {
                    realInts[i] = val; // line 20
                }
                else
                {
                    // Unable to parse
                    realInts[i] = 0;
                }
                
            }
        }
