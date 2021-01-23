    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public Patient Clone()
        {
            return new Patient 
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
