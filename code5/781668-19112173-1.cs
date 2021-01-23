    var nullable = new ObjectWithNullables() { IntArray = new int?[] { null, 1, 2, null } };
    // returns 2 elements out of 4
    //var resultA = Deserialize<ObjectWithNullables>(Serialize<ObjectWithNullables>(nullable));
    RuntimeTypeModel.Default[typeof(ObjectWithNullables)][1].SupportNull = true;
    // returns 4 elements out of 4
    var resultA = Deserialize<ObjectWithNullables>(Serialize<ObjectWithNullables>(nullable));
        
        [ProtoContract]
        public class ObjectWithNullables
        {
            [ProtoMember(1)]
            public int?[] IntArray { get; set; }
        }
