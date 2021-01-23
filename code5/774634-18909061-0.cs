    public int[] Solution(int N, int[] A)
    {
        int[] data = new int[N];
        int maxval = 0;
        int baseval = 0;
        for (int K = 0; K < A.length; K++)
        {
            int index = A[K] - 1;
            if (index < 0 || index > N)
                throw new InvalidOperationException();
            if (index < N)
                maxval = baseval + Math.Max(maxval, ++data[index]);
            else
            {
                baseval = maxval;
                data = new int[N];
            }
        }
        for (int K = 0; K < N; K++)
            data[K] += baseval;
        return data;
    }
