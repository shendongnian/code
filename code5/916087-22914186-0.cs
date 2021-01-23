     [ProtoContract]
        public class TickRecord
        {
            [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true)]
            public DateTime DT;
            [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = true)]
            public double BidPrice;
            [ProtoMember(3, DataFormat = DataFormat.FixedSize, IsRequired = true)]
            public double AskPrice;
            [ProtoMember(4, DataFormat = DataFormat.FixedSize, IsRequired = true)]
            public int BidSize;
            [ProtoMember(5, DataFormat = DataFormat.FixedSize, IsRequired = true)]
            public int AskSize;
