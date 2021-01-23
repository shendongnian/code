            public override bool Equals(object obj)
            {
                try
                {
                    ExtendedButton2Content temp = (ExtendedButton2Content)obj;
                    return temp.Index == this.Index;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("unable to compare obj in Hash Equals");
                    return false; 
                }
            }
    
            public override int GetHashCode()
            {
                return Index;
            }
