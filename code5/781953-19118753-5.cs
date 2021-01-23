    public int GetHashCode(string[] obj)
            {
                if (obj == null)
                    return 0;
    
                int hash = 17;
    
                unchecked
                {
                    foreach (string s in obj)
                        hash = hash*23 + ((s == null) ? 0 : s.GetHashCode());
                }
    
                return hash;
            }
