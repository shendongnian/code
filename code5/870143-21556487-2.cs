    public class EmployeeObject : IEquatable<EmployeeObject>
    {
    		public bool Equals(EmployeeObject other)
    		{
    			return Id == other.Id && 
                       string.Equals(Title, other.Title) && 
                       string.Equals(Desc, other.Desc);
    		}
    
    		public override bool Equals(object obj)
    		{
    			if (ReferenceEquals(null, obj)) return false;
    			if (ReferenceEquals(this, obj)) return true;
    			if (obj.GetType() != this.GetType()) return false;
    			return Equals((EmployeeObject) obj);
    		}
    
    		public override int GetHashCode()
    		{
    			unchecked
    			{
    				var hashCode = Id;
    				hashCode = (hashCode*397) ^ (Title != null ? Title.GetHashCode() : 0);
    				hashCode = (hashCode*397) ^ (Desc != null ? Desc.GetHashCode() : 0);
    				return hashCode;
    			}
    		}
    
    		public Int32 Id { get; set; }
    		public string Title { get; set; }
    		public string Desc { get; set; }
    	}
