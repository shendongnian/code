    public class Employee : IEquatable<Employee>
    {
        public bool Equals( Employee other)
        {
            return this.ID == other.ID && 
               this.Name == other.Name;
        }
    }
