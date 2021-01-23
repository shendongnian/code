    [DataContract]
    public class Data
    {
        [DataMember]
        private byte data;
        private bool bool1;
        private bool bool2;
        [OnSerializing]
        internal void OnSerializing()
        {
            data = Convert.ToByte((bool1 ? 0 : 1) & (bool2 ? 0 : 2));
        }
        [OnDeserialized]
        internal void OnDeserializing()
        {
            bool1 = (Convert.ToInt32(data) & 1) != 0;
            bool2 = (Convert.ToInt32(data) & 2) != 0;
        }
    }
