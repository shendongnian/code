    IEnumerable<int[]> getRows(int[][] possibleColumnValues, int[] rowPrefix) {
        if(!possibleValues.Any())
            return rowPrefix;
        var remainingColumns = possibleColumnValues.Skip(1).ToArray();
        foreach(var val in possibleColumnValues.First()) {
           var rowSoFar = rowPrefix.Concat(new[]{val}).ToArray(); 
           yield return getRows(remainingColumns rowSoFar);
        }
    }
