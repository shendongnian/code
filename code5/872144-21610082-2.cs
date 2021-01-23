    private string generateName(string name, int count) 
    { 
        // Find last dash
        int dashPos = name.LastIndexOf("-");
        if (dashPos == 0) return string.Format("{0}-{1}",name,count);
        
        // Extract content after last dash
        string lastEl = name.SubString(dashPos+1);
        int lastNumber;
        // Check if it is a number
        bool isNumber = int32.TryParse(lastEl, out lastNumber)
        if (isNumber){
            return string.Format("{0}-{1}", name.SubString(0, dashPos), ++lastNumber);
        }
        
        return string.Format("{0}-{1}", name, count);
    }
