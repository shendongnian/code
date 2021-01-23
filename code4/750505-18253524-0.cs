    public static IEnumerable<AnalysisResult> Distinct(AnalysisResult[] results)
    {
        var query = results.Distinct(new AnalysisResultDistinctItemComparer());
        foreach(AnalysisResult ar in query)
        {
            // Use yield return here, so that the iteration remains lazy.
            yield return ar;
        }
    }
