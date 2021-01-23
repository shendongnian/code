      // Generates 0, 1, 2, ... sequence
      public sealed class Sample: IEnumerable {
        public IEnumerator GetEnumerator() {
          for(int i = 0;; ++i)
            yield return i;
        }  
      }
