    @model TimeSpan
    
    @functions{
        public string GetPlural(int value, string text){
            if (value == 0) return string.Empty;
            if (value > 1) text +="s";
            return string.Format("{0} {1}", value, text);
        }
    }
    
    @string.Join(", ",  new[]{
                            GetPlural(Model.Days, "day"), 
                            GetPlural(Model.Hours, "hour"), 
                            GetPlural(Model.Minutes, "minute")
                        }
                       .Where(m => m != string.Empty));
