    public class InstitutionComparer : IEqualityComparer<Institution>
    {
      public bool Equals(Institution x, Institution y)
      {
        if (Object.ReferenceEquals(x, y)) 
        {
          return true;
        }
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
        {
            return false;
        }
        return x.ID == y.ID;
      }
      public int GetHashCode(Institution institution)
      {
        if (Object.ReferenceEquals(institution, null))
        {
          return 0; 
        }
        return institution.ID.GetHashCode();
      }
    }
