        public static IList<IList<int>> UpDownSeparator(IEnumerable<int> value) {
          if (Object.ReferenceEquals(null, value))
            throw new ArgumentNullException("value");
    
          List<IList<int>> result = new List<IList<int>>();
    
          List<int> current = new List<int>();
          result.Add(current);
    
          // +1 - asceding, -1 - descending, 0 - to be determined later
          int direction = 0;
    
          foreach(int item in value) {
            if (direction == 0) {
              if (current.Count > 0) {
                if (item > current[current.Count - 1])
                  direction = 1;
                else if (item < current[current.Count - 1])
                  direction = -1;
              }
    
              current.Add(item);
            }
            else if (direction < 0) {
              if (item > current[current.Count - 1]) {
                direction = 1;
                current = new List<int>() { item };
                result.Add(current);
              }
              else
                current.Add(item);
            }
            else {
              if (item < current[current.Count - 1]) {
                direction = -1;
                current = new List<int>() { item };
                result.Add(current);
              }
              else
                current.Add(item);
            }
          }
    
          return result;
        }
    
    ....
    
      List<int> list = new List<int>() { 100, 200, 300, 400, 500, 600, 500, 400, 300, 200, 100, 500, 700, 800, 900};
    
      // [[100, 200, 300, 400, 500, 600], [500, 400, 300, 200, 100], [500, 700, 800, 900]]
      IList<IList<int>> result = UpDownSeparator(list);
