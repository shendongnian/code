    public class Files : IEquatable<Files>
    {
        public string fileName { get; set; }
        public int detailId { get; set; }
    
        public bool Equals(Files other)
        {
    
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the products' properties are equal. 
            return detailId.Equals(other.detailId) && fileName.Equals(other.fileName);
        }
    
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
    
        public override int GetHashCode()
        {
    
            //Get hash code for the fileName field if it is not null. 
            int hashFileName = fileName == null ? 0 : fileName.GetHashCode();
    
            //Get hash code for the detailId field. 
            int hashDetailId = detailId.GetHashCode();
    
            //Calculate the hash code for the Files object. 
            return hashFileName ^ hashDetailId;
        }
    }
