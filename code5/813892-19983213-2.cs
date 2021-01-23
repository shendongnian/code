    class ABC {
      int A { get; set; }
      int B { get; set; }
      int C { get; set; }
      public void MethodB(int num1, int num2) {
        A = num1 + num2;
        B = num1 - num2;
        C = num1 * num2;
      }
    }
