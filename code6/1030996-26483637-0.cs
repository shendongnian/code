    [Serializable]
    class v1base : ISerializable 
    {
        public v1base() {}
        protected v1base(
            SerializationInfo info,
            StreamingContext context)
        {
            a = info.GetInt32("a");
            b = info.GetInt32("b");
        }
        public int a { get; set; }
        public int b { get; set; }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("a", a);
            info.AddValue("b", b);
        }
    }
    [Serializable]
    class v1derived : v1base
    {
        public v1derived() {}
        protected v1derived(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            c = info.GetInt32("c");
            d = info.GetInt32("d");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("c", c);
            info.AddValue("d", d);
        }
        public int c { get; set; }
        public int d { get; set; }
    }
    [Serializable]
    class v2base : ISerializable
    {
        protected v2base(
            SerializationInfo info,
            StreamingContext context)
        {
            a = info.GetInt32("a");
            b = info.GetInt32("b");
        }
        public int a { get; set; }
        public int b { get; set; }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("a", a);
            info.AddValue("b", b);
        }
    }
    [Serializable]
    class v2derived : v2base
    {
        protected v2derived(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            c = info.GetInt32("c");
            d = info.GetInt32("d");
        }
        public int c { get; set; }
        public int d { get; set; }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("c", c);
            info.AddValue("d", d);
        }
    }
