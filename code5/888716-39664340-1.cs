            public override bool Equals(object obj)
            {
                if (obj is ExtendedButton2Content)
                {
                    ExtendedButton2Content temp = (ExtendedButton2Content)obj;
                    return temp.Index == this.Index;
                }
                else
                {
                    return false;
                }
            }
    
            public override int GetHashCode()
            {
                return Index;
            }
