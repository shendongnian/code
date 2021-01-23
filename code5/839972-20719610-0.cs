      class Program
        {
            static void Main()
            {
                ProductListStoredModel stored_model = new ProductListStoredModel();
                Product p = new Product();
                stored_model.Add(p);
                stored_model.NextId = 10;
                stored_model.Pro = stored_model[0];
                string new_json = JsonConvert.SerializeObject(stored_model);
                Console.WriteLine(new_json);
                Console.ReadLine();
            }
        }
    
        [JsonObject(MemberSerialization.OptIn)]
        public class ProductListStoredModel : List<Product>
        {
            //public Product[] pro { get; set; }
            [JsonProperty]
            public int NextId { get; set; }
    
            [JsonProperty]
            public Product Pro { get; set; }
    
        }
