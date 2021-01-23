    public class Paging
    {
        public string Next { get; set; }
    }
    
    public class CategoryItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    
    public class Data
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Created_time { get; set; }
        public string Id { get; set; }
        public CategoryItem[] Category_list { get; set; }
    }
    
    public class Abc
    {
        public Data[] Data { get; set; }
        public Paging Paging { get; set; }
    }
