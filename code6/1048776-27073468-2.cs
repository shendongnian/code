        public class ProductAdd
        {
            [JsonConverter(typeof(CollectionWithNamedElementsConverter))]
            public List<ProductInformation> Products { get; set; }
        }
