    public class CostCodeSummaryViewModel
    {
        public int CostCode { get; set; }
        public int Total { get; set; }
    }
            var groupedValues = viewModels.ToList()
                .GroupBy(model => model.CostCode,
                    (i, models) => new CostCodeSummaryViewModel {CostCode = i, Total = models.Sum(model => model.Value)});
