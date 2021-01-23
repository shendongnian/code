     private bool HasData
        {
            get
            {
                return NavigationContext.QueryString.ContainsKey("data");
            }
        }
        private bool HasId
        {
            get
            {
                return NavigationContext.QueryString.ContainsKey("id");
            }
        }
        
         private string ReadValue(string key)
        {
            return NavigationContext.QueryString[key];
        }
