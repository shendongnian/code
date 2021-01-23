    class MyClass
    {
        public string name { get; set; }
        public int age { get; set; }
        [JsonExtensionData]
        private Dictionary<string, object> otherStuff { get; set; }
    }
