    public class Office : IEquatable<Office>
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public String Stuff { get; set; }
    
        // Compare by values
        public override  bool Equals(object obj)
        {
            if (obj is Office)
            {
                Office cmp = (Office) obj;
                bool result = true;
                result &= cmp.Id == this.Id;
                result &= cmp.Name == this.Name;
                result &= cmp.Stuff == this.Stuff;
                return result;
            }
            else return false;
        }
    
        // Hashcode by values
        public override int  GetHashCode()
        {
            var obj = new { Id = this.Id, Name = this.Name, Stuff = this.Stuff };
            return obj.GetHashCode();
        }
    
        // IEquatable uses overriden Equals implementation
        bool IEquatable<Office>.Equals(Office other)
        {
            return this.Equals(other);
        }
    }
