    private static string CombineCriteria(string oldCondition, string newCondition) {
        if (string.IsNullOrEmpty(oldCondition))
            return newCondition;
        return "(" + oldCondition+ ") AND (" + newCondition + ")";
    }
