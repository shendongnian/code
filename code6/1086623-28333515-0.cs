        // Input: int[] input = new int[] { 1, 2, 3};
        // Call: Console.WriteLine(PrintContSubArrays(GetContSubArrays(input)));
        // Output: 
        //       (1)
        //       (1 2)
        //       (1 2 3)
        //       (2)
        //       (2 3)
        //       (3)
        
        // Generate subsets
        static IEnumerable<int[]> GetContSubArrays(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    int[] placeholder = new int[j - i < 0 ? 0 : j - i];
                    bool isPlaceholderEmpty = true;
                    for (int k = i; k < j; k++)
                    {
                        placeholder[k - i] = arr[k];
                        isPlaceholderEmpty = false;
                    }
                    if (!isPlaceholderEmpty) yield return placeholder;
                }
            }
        }
        // Print
        static string PrintContSubArrays(IEnumerable<int[]> input)
        {
            StringBuilder sb1 = new StringBuilder();
            foreach (int[] intarr in input)
            {
                if (intarr != null)
                {
                    sb1.Append("(");
                    foreach (int intsingle in intarr)
                    {
                        sb1.AppendFormat("{0} ", intsingle);
                    }
                    sb1.Remove(sb1.Length - 1, 1);
                    sb1.Append(")");
                }
                sb1.AppendFormat(Environment.NewLine);
            }
            return sb1.ToString();
        }
