        static void CreateMappings()
        {
            ShardKey guid1 = new ShardKey(new Guid("<yourgui1d>"));
            ShardKey guid2 = new ShardKey(new Guid("<yourguid2>"));
            ShardKey guid1_next = NextShardKeyForGuid(guid1);
            ShardKey guid2_next = NextShardKeyForGuid(guid2);
            _map.CreateRangeMapping(new Range<Guid>(guid1.GetValue<Guid>(), guid1_next.GetValue<Guid>()), _shard1);
            _map.CreateRangeMapping(new Range<Guid>(guid2.GetValue<Guid>(), guid2_next.GetValue<Guid>()), _shard2);
        }
        static ShardKey NextShardKeyForGuid(ShardKey shardkey)
        {
            int len = 16;
            byte[] b = new byte[len];
            
            shardkey.RawValue.CopyTo(b, 0);
            while (--len >= 0 && ++b[len] == 0) ;
            // Treat overflow if the current key's value is the maximum in the domain
            if (len < 0)
            {
                return new ShardKey(ShardKeyType.Guid, null);
            }
            else
            {
                return ShardKey.FromRawValue(ShardKeyType.Guid, b);
            }
        }
    }
