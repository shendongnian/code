        static bool ReferenceEquals(ref int a, ref int b)
        {
            unsafe
            {
                fixed (int* pA = &a)
                {
                    fixed (int* pB = &b)
                    {
                        return pA == pB;
                    }
                }
            }
        }
