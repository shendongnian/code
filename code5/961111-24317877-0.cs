      public Room(List<T> listPar)
      {
          Random r = new Random(Environment.TickCount);
          baseList = listPar;
          var props = TypeDescriptor.GetProperties(typeof(T));
          PropertyDescriptor prop = props[r.Next(props.Count - 1)];      
    
          // How to set a comparer here, if we know prop (type, value...)
          baseList.Sort((x, y) => prop.GetValue(x).ToString().CompareTo(prop.GetValue(y).ToString()));
    
          // go do something with reordered list
       }
