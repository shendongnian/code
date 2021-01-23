    /// <summary>
    ///     Object that describes a [Postman](http://getpostman.com) folder
    /// </summary>
    public class PostmanFolderGet
    {
        /// <summary>
        ///     id of the folder
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        ///     folder name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        ///     folder description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        ///     ordered list of ids of items in folder
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public ICollection<Guid> Order { get; set; }
        /// <summary>
        ///     Name of the collection
        /// </summary>
        [JsonProperty(PropertyName = "collection_name")]
        public string CollectionName { get; set; }
        /// <summary>
        ///     id of the collection
        /// </summary>
        [JsonProperty(PropertyName = "collection_id")]
        public Guid CollectionId { get; set; }
    }
