    private static string AddFilter(string baseCondition, string newCondition) {
        if (string.IsNullOrEmpty(baseCondition))
            return newCondition;
        return "(" + baseCondition + ") AND (" + newCondition + ")";
    }
