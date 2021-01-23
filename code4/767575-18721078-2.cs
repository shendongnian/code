    public static class Helper {
        public static IEnumerable<int> EnumerateDigits(this int @this) {
            Stack<byte> stack = new Stack<byte>();
            do {
                var digit = (byte)(@this % 10);
                stack .Add(digit);
                @this /= 10;
            } while (@this != 0);
            while (stack .Count > 0)
                yield return stack.Pop();
        }
    }
