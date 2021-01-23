     public override int GetHashCode()
     {
       //(data).GetHashCode() !!! List<T>::GetHashCode()..
       return (( sx+sy+bx+by+ cx+ cy).GetHashCode()+(data).GetHashCode());
     }    
