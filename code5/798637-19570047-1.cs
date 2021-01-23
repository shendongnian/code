    private DinnerViewModel CreateDinnerViewModel()
    {
        return new DinnerViewModel {
            Meal = new Meal { Cost = 7M },
            Beverage = new Beverage { Cost = 1M },
            Desert = new Desert { Cost = 2M },
            SalesTax = 0.08M,
            SeniorDiscount = false
        }
    }
