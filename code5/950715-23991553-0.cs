    public static class MyPhpStyleExtension
    {
        public void SplitInTwo(this string str, char splitBy, out string first, out string second)
        {
            var tempArray = str.Split(splitBy);
            if (tempArray.length != 2) {
                throw new NotSoPhpResultAsIExpectedException(tempArray.length);
            }
            first = tempArray[0];
            second = tempArray[1];
        }
    }
