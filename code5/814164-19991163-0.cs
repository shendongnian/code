    private sealed class ComplexCalculationProgress
    {
      public string Name { get; set; }
      public int PercentComplete { get; set; }
    }
    private void ComplexCalculation(Object MyObject, IProgress<ComplexCalculationProgress> progress)
    {
      (...do some time consuming operation on MyObject...);
      if (progress != null)
        progress.Report(new ComplexCalculationProgress { Name = MyObject.Name, PercentComplete = 50 });
      (...do another time consuming operation on MyObject...);
      if (progress != null)
        progress.Report(new ComplexCalculationProgress { Name = MyObject.Name, PercentComplete = 100 });
    }
