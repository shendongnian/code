        public static int[] split(int N, int k)
        {
            int left = N % k > 0 ? 1 : 0;
            int[] res = new int[k + left];
            for (int i = 0; i < res.Length - left; i++)
            {
                res[i] = N / k;
            }
            if (left == 1)
            {
                res[res.Length - left] = N % k;
            }
            return res;
        }
