    class Name 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    ...
    
    var names = JsonConvert.DeserializeObject<List<Name>>(data);
