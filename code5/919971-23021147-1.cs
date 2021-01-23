    public static string GetKpiPoint(string kpiResult, string ifExceeds)
    {
    	return kpiResult.Contains("Exceeds") ? ifExceeds : null;
    }
    
    public static string[] CalculatePoints(string kpiAResult, string kpiBResult)
    {
    	return new string[] { GetKpiPoint(kpiAResult, "AHT"), GetKpiPoint(kpiBResult, "QA") };
    }
