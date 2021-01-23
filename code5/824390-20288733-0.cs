    public class DataVM
    {
        public int number { get; set; }
        public stringname { get; set; }
        
        public override bool Equals(object obj)
        {
            bool areEqual ;
    
            areEqual = false ;
            
            if((obj != null) && (obj instanceOf DataVM))
            {
                //compare fields to determine if they are equal
                areEqual = (DataVM(obj)).number == this.number ;
            }
    
            return areEqual ;
        }
        public override int GetHashCode()
        {
             //calculate a hash code base on desired properties
             return number ; 
        }
    }
