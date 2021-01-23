        public static int[] ConvertToBase(decimal base10Value, int newBase, int length)
        {
            var result = new Stack<int>();
            while(base10Value>0)
            {
                result.Push((int)base10Value % newBase);
                if (base10Value < newBase)
                    base10Value = 0;
                else
                    base10Value = base10Value / newBase;
            }
            for (var i = result.Count; i < length; i++)
                result.Push(0);
            return result.ToArray();
        }
