    public class FilesResponse2: Dictionary<string, Asset>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilesResponse"/> class.
        /// </summary>
        public FilesResponse2() {
        }
        /// <summary>
        /// Gets the collection of assets by their name.
        /// </summary>
        public Dictionary<string, Asset> Files { get { return this; } }
        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
    // deserialization:
    var result22 = JsonConvert.DeserializeObject<FilesResponse2>(json);
