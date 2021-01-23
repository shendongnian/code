    public static class MinNumberSolver
    {
        public static string GetMinString(string number, int takeOutAmount)
        {
            // "Add" the string by simply counting digit occurrance frequency.
            var digit_count = new int[10];
            foreach (var c in number)
                if (char.IsDigit(c))
                    digit_count[c - '0']++;
            // Now remove them one by one in lowest to highest order.
            // For the first character we skip any potential leading 0s
            var selected = new char[takeOutAmount];
            var start_index = 1;
            selected[0] = TakeLowest(digit_count, ref start_index);
            // For the rest we start in digit order at '0' first.
            start_index = 0;
            for (var i = 0; i < takeOutAmount - 1; i++)
                selected[1 + i] = TakeLowest(digit_count, ref start_index);
            // And return the result.
            return new string(selected);
        }
        private static char TakeLowest(int[] digit_count, ref int start_index)
        {
            for (var i = start_index; i < digit_count.Length; i++)
            {
                if (digit_count[i] > 0)
                {
                    start_index = ((--digit_count[i] > 0) ? i : i + 1);
                    return (char)('0' + i);
                }
            }
            throw new InvalidDataException("Input string does not have sufficient digits");
        }
    }
