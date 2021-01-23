    private string generateName(string name, int count) 
    { 
        int dashPos = name.LastIndexOf("-");
        if (dashPos == 0) return string.Format("{0}-{1}",name,count);
        
        string lastEl = name.SubString(dashPos+1);
        int lastNumber;
        bool isNumber = int32.TryParse(lastEl, out lastNumber)
        if (isNumber){
            return string.Format("{0}-{1}", name, lastNumber++);
        }
        
        return string.Format("{0}-{1}", name, count);
    }
