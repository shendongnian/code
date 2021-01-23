        public static void RotateRight(int[] input, int right)
        {
            for (var i = 0; i < right; i += 1)
            {
                RotateRightOne(input);
            }
        }
        public static void RotateRightOne(int[] input)
        {
            var last = input.Length - 1;
            for (var i = 0; i < last; i += 1)
            {
                input[i] ^= input[last];
                input[last] ^= input[i];
                input[i] ^= input[last];
            }
        }
