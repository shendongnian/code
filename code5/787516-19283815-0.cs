        [Column]
        public string categoriesStr {
            get
            {
                return string.Join(",", categories);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    categories = new List<int>();
                }
                else
                {
                    categories = value.Split(',').Select((val) => int.Parse(val)).ToList();
                }
            } 
        }
        public List<int> categories { get; set; }
