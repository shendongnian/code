    public static int calcValueMS(FPT doc, int score)
    {
            return doc.PositionSection.ManagedStrategyAssets
                .Where(a => a.AssetRiskData.RiskMeasure.RiskRating.Id != null && a.AssetRiskData.RiskMeasure.RiskRating.Id == score )
                .SelectMany(h => h.Holdings)
                .Sum(v => v.CurrentValue);
    }
