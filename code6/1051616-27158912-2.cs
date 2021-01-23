    public struct Category // turned out that Category is a struct
    {
        public int Field {get; set; } // for demo purpose only
        public override bool Equals(Object that) 
        {
             if (that == null)
             {
                 return false;
             }
             else
             {
                 if (that is Category)
                 {
                     // select the fields you want to compare between the 2 objects
                     return this.Field == (that as Category).Field;
                 }
                
                 return false;
             }
        }
    }
