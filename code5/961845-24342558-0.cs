    [JsonObject(MemberSerialization.OptIn)]
    public class Test
    {
        [JsonProperty]
        public int x = 1;
        // static member we want serialized with each instance
        public static int y = 2;
        // private accessor to allow Json.net to serialize the static member
        [JsonProperty("y")]
        private int y1 { get { return y; } }
    }
