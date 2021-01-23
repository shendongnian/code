    public class Vessel : IEquatable<Vessel>
        {
            public int Id { get; set; }
    
            public bool Equals(Vessel other)
            {
                return Id == other.Id ; 
            }
    
            public override int GetHashCode()
            {
                return Id;
            }
            public override bool Equals(object obj)
            {
                var vessel = obj as Vessel;
                return vessel != null && vessel.Id == this.Id;
            }
        }
