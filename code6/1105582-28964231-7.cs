        public class Member : IEquatable<Member>
        {
            public bool Equals(Member other)
            {
                return Id == other.Id;
            }
            public override bool Equals(object obj) 
            {
                var other = obj as Member;
                if (other == null)
                    return false;
                
                return Equals(other);
            }
            public override int GetHashCode()
            {
                // Whenever IEquatable is implemented, GetHashCode() must also be overridden.
                return Id.GetHashCode();
            }
         
            // Rest of the class...
        }
