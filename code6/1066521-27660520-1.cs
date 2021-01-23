    public static class Extensions
    {
        public static IEnumerable<byte[]> ToBytePairs(this byte[] array)
        {
            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var bytePair = new byte[2];
                bytePair[0] = (byte)enumerator.Current;
                enumerator.MoveNext();
                bytePair[1] = (byte)enumerator.Current;
                yield return bytePair;
            }
        }
    }
