    public class Category
    {
        public int field; // bad implementaion - for demo purpose only
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
                     return this.field == (that as Category).field;
                 }
                
                 return false;
             }
        }
    }
