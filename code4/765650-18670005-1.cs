    public class BeverageManager { 
      private List<Beverage> _beverage = new List<Beverage>();
      private List<Type> _types = new List<Type>();
      private HashSet<Type> _multipleAllows = new HashSet<Type>();
      public BeverageManager(Type[] multipleAllows) {  
        foreach (var allowed in multipleAllows)
          _multipleAllows.Add(allowed); 
      }
      public double Price { 
        get { 
          return (from bev in _beverage
                  select bev.Price).Sum();
        }
      }
      public bool HasType(Type t) { 
        return _types.Contains(t); 
      }
      public bool AddBeverage(Beverage bev) { 
        if (HasType(bev.GetType()) && !_multipleAllows.Contains(bev.GetType()))
          return false; 
        _types.Add(bev.GetType()); 
        _beverage.Add(bev); 
        return true; 
      }
    }
