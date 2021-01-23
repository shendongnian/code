    public class IPRange
    {
        public IPAddress Start { get; set; }
        public IPAddress End { get; set; }
        public int Count { get; set; }
    
        public static IEnumerable<IPRange> Split(IPAddress ipStart, IPAddress ipEnd, int rangeCount)
        {
            // Assuming running on little-endian machine to keep.
            // Thus Reverse() is necessary to convert between network order and little-endian.
            var start = BitConverter.ToInt32(ipStart.GetAddressBytes().Reverse().ToArray(), 0);
            var end = BitConverter.ToInt32(ipEnd.GetAddressBytes().Reverse().ToArray(), 0);
    
            var rangeSize = (end - start + 1) / rangeCount;
            var remains = (end - start + 1) % rangeCount;
    
            while (start < end)
            {
                var rangeEnd = Math.Min(start + rangeSize - 1, end);
                if (remains > 0)
                {
                    // Take one from the remains to keep size of each range more balance
                    rangeEnd++;
                    remains--;
                }
    
                yield return new IPRange
                {
                    Start = new IPAddress(BitConverter.GetBytes(start).Reverse().ToArray()),
                    End = new IPAddress(BitConverter.GetBytes(rangeEnd).Reverse().ToArray()),
                    Count = rangeEnd - start + 1
                };
                start = rangeEnd + 1;
            }
        }
    }
