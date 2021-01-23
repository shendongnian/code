            // Returns true if this class is a true subclass of c.  Everything 
            // else returns false.  If this class and c are the same class false is
            // returned. 
            //
            [System.Runtime.InteropServices.ComVisible(true)]
            [Pure]
            public virtual bool IsSubclassOf(Type c) 
            {
                Type p = this; 
                if (p == c) 
                    return false;
                while (p != null) { 
                    if (p == c)
                        return true;
                    p = p.BaseType;
                } 
                return false;
            } 
