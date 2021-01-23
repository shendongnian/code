    class Program {
        static void Main(string[] args) {
            List<Product> products = new List<Product> 
                                            {   
                                                new Product("product 1"),
                                                new Product("product 2"),
                                                new Product("product 3"),
                                                new Product("product 4"),
                                                new Product("product 5")
                                            };
            /** do some more work here in this segment */
            // now call your GetDetails() method in a nicer Object Oriented (subjective) manner
            for(int i=0; i<5; i++) {
                Console.WriteLine("\"" + (i+1) + ".\"" + products[i].GetDetails() + "\n\n");
            }
            Console.ReadLine();
        }
        private class Product {
            public Product(string data) {
                Data = data;
            }
            public string Data { get; set; }
            public string GetDetails() {
                return "The initial data string is:\t" + Data;
            }
        }
    }
