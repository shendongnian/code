        public static unsafe float TestMethod3()
        {
            float[] samples = new float[5000000];
            for (var ii = 0; ii < 5000000; ii++)
            {
                samples[ii] = 32768 + (ii != 0 ? samples[ii - 1] : 0);
            }
            return samples[5000000 - 1];
        }
        public static unsafe float TestMethod4()
        {
            float[] prev = new float[5000000];
            fixed (float* samples = &prev[0])
            {
                for (var ii = 0; ii < 5000000; ii++)
                {
                    samples[ii] = 32768 + (ii != 0 ? samples[ii - 1] : 0);
                }
                return samples[5000000 - 1];
            }
        }
        public static unsafe float TestMethod5()
        {
            var ptr = Marshal.AllocHGlobal(5000000 * sizeof(float));
            try
            {
                float* samples = (float*)ptr;
                for (var ii = 0; ii < 5000000; ii++)
                {
                    samples[ii] = 32768 + (ii != 0 ? samples[ii - 1] : 0);
                }
                return samples[5000000 - 1];
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
