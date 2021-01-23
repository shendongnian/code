    public class MyClass : IBackwardCompatibilitySerializer 
    {
        // public bool Included { get; set; } Old variable
        public bool IsIncluded { get; set; } // New Variable
        public void OnUnknownElementFound(string unknownElement, string value) 
        {
             switch(unknownElement)
             {
                  case "Included":
                        IsIncluded = bool.Parse(value);
                        return;
             }
        }
    }
