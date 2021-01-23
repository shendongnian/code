     public class lin : IEquatable<lin>
            {
                public string DB_Name;
                public string Object_Name;
    
                public bool Equals(lin other)
                {
                    if (ReferenceEquals(null, other)) return false;
                    if (ReferenceEquals(this, other)) return true;
                    return string.Equals(DB_Name, other.DB_Name) && string.Equals(Object_Name, other.Object_Name);
                }
    
                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj)) return false;
                    if (ReferenceEquals(this, obj)) return true;
                    if (obj.GetType() != this.GetType()) return false;
                    return Equals((lin) obj);
                }
    
                public override int GetHashCode()
                {
                    unchecked { return ((DB_Name != null ? DB_Name.GetHashCode() : 0)*397) ^ (Object_Name != null ? Object_Name.GetHashCode() : 0); }
                }
    
                public static bool operator ==(lin left, lin right)
                {
                    return Equals(left, right);
                }
    
                public static bool operator !=(lin left, lin right)
                {
                    return !Equals(left, right);
                }
            }
