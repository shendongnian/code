    CarTypeComparer compareCarTypes = new CarTypeComparer();
    if (!List.contains(car, compareCarTypes))
    {
       // insert car into list
    }
    class CarTypeComparer : IEqualityComparer<ICar<T>>
    {
       public bool Equals(ICar<T> car1, ICar<T> car2)
       {
          if (car1.GetType().FullName == car2.GetType().Fullname)
          {
              return true;
          }
          else 
          {
              return false;
          }
          
       }
       // implement GetHashCode() ....
    }
