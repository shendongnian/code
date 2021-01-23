        class Product
        {
            public string ProductNumber { get; set; }
            public override string ToString()
            {
                return ProductNumber;
            }
        }
        private List<Product> productList = new List<Product>();
        productList  = GetProducts(); //your sql function.
        private void FillComboBox()
        {
            comboBox1.Items.Clear();
            foreach (var p in productList)
            {
                comboBox1.Items.Add(p); 
            }
        }
