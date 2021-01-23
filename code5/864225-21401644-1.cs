    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Test
    {
        class ChannelTest
        {
            public static void Test()
            {
                var dict = new Dictionary<ChannelID, Channel>();
                var a = new Channel(new ChannelID(0, Tower.A), 0.5);
                var b = new Channel(new ChannelID(7, Tower.B), 0.35);
                dict.Add(a.ChanID, a);
                dict.Add(b.ChanID, b);
                // To get a channel from the ID
                // Just create a new ID object with the same values
                var aRef = dict[new ChannelID(0, Tower.A)];
                var bRef = dict[new ChannelID(7, Tower.B)];
                // If you want the sorted channels - use linq
                // This will give you the best 10
                var sorted = dict.Values.OrderByDescending(c => c.AvailableProbability).Take(10).ToList();
            }
        }
        class ChannelID
        {
            public int ChanNumber { get; private set; }
            public Tower ChanTower { get; private set; }
            public ChannelID(int chanNumber, Tower chanTower)
            {
                ChanNumber = chanNumber;
                ChanTower = chanTower;
            }
            public override bool Equals(object obj)
            {
                if (!(obj is ChannelID))
                {
                    return false;
                }
                var o = (ChannelID)obj;
                return this.ChanNumber == o.ChanNumber
                    && this.ChanTower == o.ChanTower;
            }
            public override int GetHashCode()
            {
                // Using random prime multipliers to get a good hash code distribution
                // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
                return 17
                    + 23 * this.ChanNumber.GetHashCode()
                    + 23 * this.ChanTower.GetHashCode();
            }
        }
        class Channel : IComparable<Channel>
        {
            public ChannelID ChanID { get; private set; }
            public double AvailableProbability { get; private set; }
            public Channel(ChannelID chanID, double availableProbability)
            {
                ChanID = chanID;
                AvailableProbability = availableProbability;
            }
            public int CompareTo(Channel other)
            { return other.AvailableProbability.CompareTo(AvailableProbability); }
        }
        enum Tower
        {
            A,
            B,
            C
        }
    }
