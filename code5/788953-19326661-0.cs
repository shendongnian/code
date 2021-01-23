    class Program
    {
        static void Main(string[] args)
        {
            Image image1 = new Image { Id = 1, Url = "http://contoso.com/product1.png" };
            Image image2 = new Image { Id = 2, Url = "http://contoso.com/product2.png" };
            Product product = new Product 
            { 
                MainImage = image1,
                AllImages = new List<Image> { image1, image2 }
            };
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            var writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented };
            var serializer = JsonSerializer.Create();
            serializer.Serialize(writer, product);
            Console.WriteLine(sb.ToString());
        }
    }
