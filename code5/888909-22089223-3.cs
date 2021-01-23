      bool IsEqual(this Double a, Double b, Double offset) {
        return (Math.Abs(a - b) < offset);
      }
      bool IsEqual(this Single a, Single b, Single offset) {
        return (Math.Abs(a - b) < offset); 
      }
      bool IsEqual(this long a, long b, long offset) {
        return (Math.Abs(a - b) < offset);
      }
      bool IsEqual(this int a, int b, int offset) {
        return (Math.Abs(a - b) < offset);
      }
      ...
