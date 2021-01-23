        public static void ShiftRight(int[] input, int right)
        {
            for (var i = 0; i < right; i += 1)
            {
                ShiftRightOne(input);
            }
        }
        public static void ShiftRightOne(int[] input)
        {
            var last = input.Length - 1;
            for (var i = 0; i < last; i += 1)
            {
                input[i] ^= input[last];
                input[last] ^= input[i];
                input[i] ^= input[last];
            }
        }
