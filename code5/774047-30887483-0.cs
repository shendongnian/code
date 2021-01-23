    public int solution(int X, int[] A) {
            int result = -1;
             Dictionary<int, int> jumps = new Dictionary<int, int>();
                int res =  (X*(X+1))/2;
                int sum = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (!jumps.ContainsKey(A[i]))
                    {
                        sum = sum + A[i];
                        jumps.Add(A[i],i);
                        if (sum == res)
                        {
                            result = i;
                            break;
                        }
                    }
                }
                return result;
        }
