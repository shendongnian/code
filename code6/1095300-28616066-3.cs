    [DataContract]
    public class Package<T>
    {
        [DataMember]
        public List<T> Objects = new List<T>();
        public Package() { }
        public void AddObject(T dto)
        {
            this.Objects.Add(dto);
        }
    }
