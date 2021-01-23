     List<BudgtedData> budgetData = new List<BudgtedData>();
     budgetData.Add(new BudgtedData() { BudgetedCpmDataId = 1, ForecastMonth = 12, ForecastYear = 2014 });
     budgetData.Add(new BudgtedData() { BudgetedCpmDataId = 1, ForecastMonth = 1, ForecastYear = 2014 });
     budgetData.Add(new BudgtedData() { BudgetedCpmDataId = 1, ForecastMonth = 1, ForecastYear = 2013 });
     budgetData.Add(new BudgtedData() { BudgetedCpmDataId = 2, ForecastMonth = 2, ForecastYear = 2014 });
     budgetData.Add(new BudgtedData() { BudgetedCpmDataId = 2, ForecastMonth = 1, ForecastYear = 2015 });
     var res = budgetData.Where(r => ((r.ForecastYear == (DateTime.Today.Year - 1) && r.ForecastMonth >= DateTime.Today.Month) || (r.ForecastYear == DateTime.Today.Year && r.ForecastMonth < DateTime.Today.Month))).ToList();
     foreach (BudgtedData item in res)
     {
         Console.WriteLine(item.ForecastYear + "  "+ item.ForecastMonth);
     }
