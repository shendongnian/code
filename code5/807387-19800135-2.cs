    [DataContract()]
    public class MyClass
    {
        private ThirdPartyClass m_ThirdPartyClass;
        public ThirdPartyClass ThirdPartyClass
        {
            get
            {
                return m_ThirdPartyClass;
            }
            set
            {
                m_ThirdPartyClass = value;
            }
        }
        [DataMember()]
        public ThirdPartyClassSerializable ThirdPartyClassSerialized
        {
            get
            {
                return new ThirdPartyClassSerializable(this.ThirdPartyClassNonSerialized);
            }
            set
            {
                this.ThirdPartyClass = value.GetThirdPartyClass();
            }
        }
    }
