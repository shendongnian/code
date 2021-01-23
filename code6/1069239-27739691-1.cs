    //Created MyObject to resemble the JSON object graph for easy deserialization
    class MyObject
    {
         public string Status { get; set; }
         public Category[] Categories { get; set; }
         //Similar to categories, You can create properties for fields, subcategories etc., as needed.
    }
    class Category
    {
         public int id { get; set; }
         public string name { get; set; }
         public int number { get; set; }
         public int clientsCount { get; set; }
    
    }
