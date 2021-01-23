    class ObjectWithProperties
    {
        public Dictionary<string, object> Properties { get; set; }
        
        public ObjectWithProperties()
        {
            Properties = new Dictionary<string, object>();
        }
    }
    // instantiate in your other class / app / whatever
    var objWithProperties = new ObjectWithProperties();
    // set
    objWithProperties.Properties["foo"] = "bar";
    // get
    var myFooObj = objWithProperties.Properties["foo"];   // myFooObj = "bar"
