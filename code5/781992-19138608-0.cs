    private static readonly ExpressionMethod<Func<AquaReportsRepository, string, bool>> _IsPhysicalItem =
        ExpressionMethod.Create((AquaReportsRepository ardc, string i) => ardc._AquaReportsDC.Aqua_IsPhysicalItem(i) ?? true);
    [MapToExpression("_IsPhysicalItem")]
    public bool IsPhysicalItem(string itemNumber)
    {
        return _IsPhysicalItem.Invoke(this, itemNumber);
    }
