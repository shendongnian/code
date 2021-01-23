    var query = doc.NonFinancialAssetSection.NonFinancialAssets
                    .Where(m => m.Owner.Id == ownerId && m.InvestableAsset == true);
    double sum;
    if (condition)
    {
        sum = query.Sum(s => s.CurrentValue);
    }
    else
    {
        sum = query.Sum(s => s.ProposedValue);
    }
