    public class MyClass : IBackwardCompatibilitySerializer 
    {
        public bool IsIncluded { get; set; }
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
