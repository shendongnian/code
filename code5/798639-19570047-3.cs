    private DinnerViewModel CreateTenDollarsDinner()
    {
        return new DinnerViewModel {
            Meal = new Meal { Cost = 7M },
            Beverage = new Beverage { Cost = 1M },
            Desert = new Desert { Cost = 2M },
            SalesTax = 0.08M,
            SeniorDiscount = false
        };
    }
    [TestMethod]
    public void CalculatorReturnsCorrectTotalForNonSenior()
    {
        DinnerViewModel dvm = CreateTenDollarsDinner();    
        Calculator calc = new Calculator();
        Assert.AreEqual(10.80M, calc.Total(dvm));
    }
