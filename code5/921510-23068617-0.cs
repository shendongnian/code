     Type t = src.GetType();
     
     if (t.GetProperty(propName).GetGetMethod().IsStatic)
     {   
         src = null;
     }
     return t.GetProperty(propName).GetValue(src, null);
