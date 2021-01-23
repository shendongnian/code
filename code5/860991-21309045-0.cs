    public class ABC
        {
            public int one;
            public string two;
            public int three;
            
            public override string ToString()
            {
                string names = String.Empty;
                System.Reflection.FieldInfo[] infos = this.GetType().GetFields();
    
                foreach (System.Reflection.MemberInfo inf in infos)
                {
                    if (names == String.Empty)
                    {
                        names = inf.Name;
                    }
                    else
                    {
                        names += ';' + inf.Name;
                    }
                }
    
                return names;
            }
        }
