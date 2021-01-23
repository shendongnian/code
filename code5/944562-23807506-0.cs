        public int SolveProblem004()
        {
            int result = 0;
            for (int a = 999; a >= 100; --a) {
                for (int b = 999; b >= a; --b) {
                    int product = a * b;
                    if (product <= result) break;
                    if (IsPalindromic(product)) { result = product; break; }
                }
            }
            return result;
        }
        public static bool IsPalindromic(int i)
        {
            return i == Reverse(i);
        }
        public static int Reverse(int number)
        {
            if (number < 0) return -Reverse(-number);
            if (number < 10) return number;
            int reverse = 0;
            while (number > 0) {
                reverse = reverse * 10 + number % 10;
                number /= 10;
            }
            return reverse;
        }
