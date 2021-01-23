        public class StringGuidConverter: JsonConverter {
            public override bool CanConvert(Type objectType) {
                return objectType == typeof(string);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
                return new Guid((string)reader.Value);
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
                writer.WriteValue(((Guid)value).ToString("N"));
            }
        }
    
        public class Asset {
            /// <summary>
            /// Initializes a new instance of the <see cref="Asset"/> class.
            /// </summary>
            public Asset() {
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Asset"/> class.
            /// </summary>
            /// <param name="fileId">The file ID.</param>
            /// <param name="signature">The file signature.</param>
            [JsonConstructor]
            public Asset(string fileId, Guid signature) {
                this.FileId = fileId;
                this.Signature = signature;
            }
    
            /// <summary>
            /// Gets the file ID to be used with the render service.
            /// </summary>
            [JsonProperty("file_id")]
            public string FileId { get; private set; }
    
            /// <summary>
            /// Gets file signature to be used with the render service.
            /// </summary>
            [JsonProperty("signature")]
            [JsonConverter(typeof(StringGuidConverter))]
            public Guid Signature { get; private set; }
    
            /// <summary>
            /// Gets the JSON representation of this instance.
            /// </summary>
            /// <returns>Returns a JSON <see cref="String"/>.</returns>
            public override string ToString() {
                return JsonConvert.SerializeObject(this);
            }
        }
    
        public class FilesResponse {
            /// <summary>
            /// Initializes a new instance of the <see cref="FilesResponse"/> class.
            /// </summary>
            public FilesResponse() {
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="FilesResponse"/> class.
            /// </summary>
            /// <param name="files">A collection of assets by their name.</param>
            [JsonConstructor]
            public FilesResponse(Dictionary<string, Asset> files) {
                this.Files = files;
            }
    
            /// <summary>
            /// Gets the collection of assets by their name.
            /// </summary>
            [JsonProperty]
            public Dictionary<string, Asset> Files { get; private set; }
    
            /// <summary>
            /// Gets the JSON representation of this instance.
            /// </summary>
            /// <returns>Returns a JSON <see cref="String"/>.</returns>
            public override string ToString() {
                return JsonConvert.SerializeObject(this);
            }
        }
    
        class Test {
            public static void Run() {
                var json = @"
    {
      ""map_waypoint"": { ""file_id"": 157353, ""signature"": ""32633AF8ADEA696AE32D617B10D3AC57"" },
      ""map_waypoint_contested"": { ""file_id"": 102349, ""signature"": ""32633AF8ADEA696AE32D617B10D3AC57"" },
      ""map_waypoint_hover"": { ""file_id"": 157354, ""signature"": ""32633AF8ADEA696AE32D617B10D3AC57"" }
    }";
    
                
                var result2 = JsonConvert.DeserializeObject<FilesResponse>(json);
                var result3 = new FilesResponse(JsonConvert.DeserializeObject<Dictionary<string, Asset>>(json));
            }
        }
