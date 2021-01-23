    var listOfNullable = new List<Nullable<int>>() { null, 1, null, 2 };
    var listOfObjects = new List<NullHolder<int?>>() { 
            new NullHolder<int?>(){ Value=null },
            new NullHolder<int?>(){ Value=1 },
            new NullHolder<int?>(){ Value=null },
            new NullHolder<int?>(){ Value=1 }
    };
    // throws exception
    //var resultA = Deserialize<List<int?>>(Serialize<List<int?>>(listOfNullable)); 
    // works
    var resultB = Deserialize<List<NullHolder<int?>>>(Serialize<List<NullHolder<int?>>>(listOfObjects));
        
        [ProtoContract]
        public class NullHolder<T>
        {
            [ProtoMember(1)]
            public T Value { get; set; }
        }
