    static void Main(string[] args)
    {              
        int[] A = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
        var set = new HashSet<int>();
        for (int i = 0; i < A.Length - 1; i++) {
            int count = 0;
            for (int j = i; j < A.Length - 1; j++) {
                if (A[i] == A[j + 1] && !set.Contains(A[i]))
                    count++;
            }
            set.Add(A[i]);
            if (count > 0) {
                Console.WriteLine("{0} occurs {1} times", A[i], count + 1);
                Console.ReadKey();
            }
        }
    }
