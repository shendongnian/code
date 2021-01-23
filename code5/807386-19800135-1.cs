    [DataContract()]
    public class ThirdPartyClassSerializable
    {
        private ThirdPartyClass m_TPC = new ThirdPartyClass();
        public ThirdPartyClassSerializable();
        public ThirdPartyClassSerializable(ThirdPartyClass oTPC)
        {
            m_TPC = oTPC;
        }
        public ThirdPartyClass GetThirdPartyClass()
        {
            return m_TPC;
        }
        [DataMember()]
        public int Property1
        {
            get
            {
                return m_TPC.Property1;
            }
            set
            {
                m_TPC.Property1 = value;
            }
        }
        [DataMember()]
        public string Property2
        {
            get
            {
                return m_TPC.Property2;
            }
            set
            {
                m_TPC.Property2 = value;
            }
        }
    }
