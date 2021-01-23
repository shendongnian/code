    public static int calcValueMS(FPT doc, int score)
    {
        return doc.PositionSection.ManagedStrategyAssets
                  .Where(a => a.AssetRiskData.RiskMeasure.RiskRating.Id.HasValue)
                  .Where(a.AssetRiskData.RiskMeasure.RiskRating.Id.Value == score)
                  .SelectMany(h => h.Holdings)
                  .Sum(v => v.CurrentValue);
    }
