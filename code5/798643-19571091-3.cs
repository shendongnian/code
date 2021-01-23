    [TestMethod]
    public void TotalCostOfDinnerReturnsCorrectTotalForNonSenior()
    {
        DinnerViewModel dvm = new DinnerViewModel
        {
            Meal = new Meal { Cost = 7M },
            Beverage = new Beverage { Cost = 1M },
            Desert = new Desert { Cost = 2M },
            SalesTax = 0.08M,
            SeniorDiscount = false
        };
        decimal expected = 10.80M;
        decimal actual = dvm.TotalCostOfDinner;
        Assert.AreEqual(expected, actual, "The actual value does not match the expected value.");
    }
