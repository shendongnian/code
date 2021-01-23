        class Offices:IEquatable<Offices>
        {
            public int ID { get; set; }
            public string name { get; set; }
    
    
    
            public bool Equals(Offices other)
            {
                return this.ID.Equals(other.ID);
            }
    
            public override int GetHashCode()
            {
                return this.ID.GetHashCode();
            }
        }
