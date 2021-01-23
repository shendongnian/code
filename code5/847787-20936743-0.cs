    public static class NumSplit
    {
        public static int[] NumSplit(this int iNum, int div)
        {
            var CountInts = Enumerable.Repeat(div, iNum / div);
            var leftover = iNum % div;
            return leftover > 0 ? CountInts.Concat(new int[] { leftover }).ToArray() : CountInts.ToArray();
        }
    }
