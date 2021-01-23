        public int[] solution(int N, int[] A)
        {
            int[] result = new int[N];
            int maximum = 0;
            int resetlimit = 0;
            for (int K = 0; K < A.Length; K++)
            {
                if (A[K] < 1 || A[K] > N + 1)
                {
                    throw new InvalidOperationException();
                }
                if (A[K] >= 1 && A[K] <= N)
                {
                    if (result[A[K] - 1] < resetlimit)
                    {
                        result[A[K] - 1] = resetlimit + 1;
                    }
                    else
                    {
                        result[A[K] - 1]++;
                    }
                    if (result[A[K] - 1] > maximum)
                    {
                        maximum = result[A[K] - 1];
                    }
                }
                else
                {
                    resetlimit = maximum;
                    result = Enumerable.Repeat(maximum, result.Length).ToArray();
                }
            }
            //for (int i = 0; i < result.Length; i++)
            //{
            //    result[i] = Math.Max(resetlimit, result[i]);
            //}
            return result;
        }
    }
