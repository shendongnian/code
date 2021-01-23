        public void ListInts(params int[] inVals)
        {
            if (inVals!=null)
            {
                Array.ForEach(inVals, (x) => Console.WriteLine("{0}", 10*x));
            }
        }
