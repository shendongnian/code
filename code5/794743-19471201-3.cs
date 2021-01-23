    FoodData_SortByPriceByAscendingOrder fAsc = new FoodData_SortByPriceByAscendingOrder();
            lines.Sort(fAsc);
            FoodData_SortByPriceByDescendingOrder fDesc = new FoodData_SortByPriceByDescendingOrder();
            lines.Sort(fDesc);
            FoodData_SortByName fByName = new FoodData_SortByName();
            lines.Sort(fByName);
