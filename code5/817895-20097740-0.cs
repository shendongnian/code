      public sealed class SomeResultWithDescription<TItem>: IReadOnlyList<TItem> {
        private List<TItem> m_Problems;
        private Boolean m_Success = true; // <- the field may be redundant 
    
        // may be redundant: if there's no situation when the result is falure
        // even if there're no problems enlisted
        internal SomeResultWithDescription(List<TItem> problems, Boolean success)
          : this(problems) {
    
          m_Success = success;
        }
    
        internal SomeResultWithDescription(List<TItem> problems)
          : base() {
    
          if (Object.ReferenceEquals(null, problems))
            m_Problems = new List<TItem>();
          else
            m_Problems = problems;
        }
            
        public IReadOnlyList<TItem> Problems {
          get {
            return m_Problems;
          }
        }
    
        public Boolean Success {
          get {
            if (!m_Success)
              return false;
            else if (m_Problems.Count > 0)
              return false;
    
            return true;
          }
        }
    
        public Boolean ToBoolean() {
          return Success;
        }
    
        public static implicit operator Boolean(SomeResultWithDescription<TItem> value) {
          if (Object.ReferenceEquals(null, value))
            return false;
    
          return value.ToBoolean();
        }
    
        public TItem this[int index] {
          get {
            return m_Problems[index];
          }
        }
    
        public int Count {
          get {
            return m_Problems.Count;
          }
        }
    
        public IEnumerator<TItem> GetEnumerator() {
          return m_Problems.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
          return m_Problems.GetEnumerator();
        }
      }
    
      ...
    
      // Your method will be
      SomeResultWithDescription<T> TrySomething(IEnumerable<T> items)
      {
        //...
     
        return new SomeResultWithDescription<T>(listOfProblemItems);
      }
    
      // So you can do
      // 1. Just do if no problems detected
      if (TrySomething(items)) { 
        ...
      }
    
      // 2. Do if no problems, analyze if there're problems
      var result = TrySomething(items);
    
      if (result) { 
        ... // no problems
      }
      else { // <- some problems to analyze
        foreach (var problem in result) {
          ...
        }
      }
