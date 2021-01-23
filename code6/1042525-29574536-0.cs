    public class FbData<T> {
        public IList<T> Data { get; set; }
    }
    public class UserPermission {
        public string Permission { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public bool Granted { get { return Status.ToLower() == "granted"; } }
    }
