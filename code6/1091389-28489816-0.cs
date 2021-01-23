    public class Parent
    {
        [JsonIgnore] 
        public Child ReadOnlyChild
        {
            get
            {
                return Child;
            }
        }
    
        public Child Child {get; set;}
    }
