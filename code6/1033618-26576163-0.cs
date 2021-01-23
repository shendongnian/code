    bool check = true;
    if (a.Length == b.Length)
    {
       for (int i = 0; i < a.Length; i++)
       {
          if (!a[i].Equals(b[i]))
          {
                check = false;
                break;
           }
                  
       }
       return check;
    }
    else 
      return false;
