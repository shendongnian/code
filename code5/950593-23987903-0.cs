    public class MyClass
            {
             
                public int First { get; set; }
                public string Name { get; set; }
              
            }
    
     var abc = JsonConvert.DeserializeObject<MyClass>(jsonData);
