    // Define other methods and classes here
    public class A
    {
        public virtual int[] prop1 { get; set; }
        public virtual string prop2 { get; set; }
        public virtual string prop3 { get; set; }
    }
    public class B : A
    {
        public Dictionary<int, int> prop4;
        public override int[] prop1
        {
            get
            {
                return m_WrappedAInstance.prop1;
            }
            set
            {
                m_WrappedAInstance.prop1 = value;
            }
        }
        public override string prop2
        {
            get
            {
                return m_WrappedAInstance.prop2;
            }
            set
            {
                m_WrappedAInstance.prop2 = value;
            }
        }
        public override string prop3
        {
            get
            {
                return m_WrappedAInstance.prop3;
            }
            set
            {
                m_WrappedAInstance.prop3 = value;
            }
        }
        A m_WrappedAInstance = null;
        public B(int[] keys, A a)
        {
            m_WrappedAInstance = a;
            prop4 = new Dictionary<int, int>();
            if (keys.Length == a.prop1.Length)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    prop4.Add(keys[i], a.prop1[i]);
                }
            }
            else
            {
                throw new Exception("something wrong");
            }
        }
    }
