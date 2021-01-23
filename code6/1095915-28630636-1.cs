    var ReportingData = ReportListQuery
        .Where(Item => Item.Category == "expense")
        .GroupBy(item => item.Title)
        .Select(itemGroup => new
        {
            Percentage = Math.Round((itemGroup.Sum(item => item.Amount) / MonthExpense) * 100),
            ExpenseTitle = itemGroup.Key,
            ExpenseCalculation = itemGroup.Sum(item => item.Amount)
            TotalTagAmounts = itemGroup
                .SelectMany(item => item.Tags.Select(tag => new { Tag = tag, Amount = amount})
                .GroupBy(tagAmount => tagAmount.Tag)
                .Select(tagAmountGroup => new 
                { 
                    Tag = tagAmountGroup.Key, 
                    TotalAmount = tagAmountGroup.Sum(tagAmount => tagAmount.Amount)
                })
        });
