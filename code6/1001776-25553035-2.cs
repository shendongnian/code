    public void DoWork(IProgress<CalculatorProgress> progress = null)
    {
      for (int i = 0; i < 10; i++)
      {
        var result = calculator.Calculate();
        DoSomethingWithCalculationResult(result);
        DoLightWork();
        if (progress != null)
          progress.Report(new CalculatorProgress(...));
      }
    }
