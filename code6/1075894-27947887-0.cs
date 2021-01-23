        [ProtoContract(SkipConstructor = true)]
        public class PC
        {
            private int _something = 42;
            public int Something { get { return _something; } }
            public PC(string foo)
            {
            }
        }
    In this case, `Something` will return `0` on a deserialized object.
