    bool isMatched = IsValid("adc,1,2,345,flos");   
         
        private bool IsValid(string value)
        {
                return Regex.IsMatch(value, @"^([^,](,[^,])*)?$");
        }
