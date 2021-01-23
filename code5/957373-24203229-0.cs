        public static unsafe void TestMethod3()
        {
            float[] samples = new float[5000000];
            for (var ii = 0; ii < 5000000; ii++)
            {
                samples[ii] = 32768;
            }
        }
        public static unsafe void TestMethod4()
        {
            float[] prev = new float[5000000];
            fixed (float* samples = &prev[0])
            {
                for (var ii = 0; ii < 5000000; ii++)
                {
                    samples[ii] = 32768;
                }
            }
        }
        public static unsafe void TestMethod5()
        {
            var ptr = Marshal.AllocHGlobal(5000000 * sizeof(float));
            try
            {
                float* samples = (float*)ptr;
                for (var ii = 0; ii < 5000000; ii++)
                {
                    samples[ii] = 32768;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
