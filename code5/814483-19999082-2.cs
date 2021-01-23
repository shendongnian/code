    public class ManifestRepository
    {
        public IList<manifest> Manifests { get; set; }
        public ManifestRepository()
        {
            Manifests = new List<manifest>();
        }
    }
