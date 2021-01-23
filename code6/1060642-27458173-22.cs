    void MyMethod()
    {
      // Gratuituous braces:
      {
          var foo = new ExpensiveClass();
      }
      {
          Bar foo = new Bar(); // Don't repurpose, it impairs readability!
      }
      Thread.Sleep(TimeSpan.FromSeconds(10));
      GC.Collect();
      GC.WaitForPendingFinalizers();
      <-- Point "X"
    }
