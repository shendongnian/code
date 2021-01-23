    IEnumerable<int[]> getRows(int[][] possibleColumnValues, int[] rowPrefix) {
        if(possibleColumnValues.Any()) { //can't return early when using yield
            var remainingColumns = possibleColumnValues.Skip(1).ToArray();
            foreach(var val in possibleColumnValues.First()) {
               var rowSoFar = rowPrefix.Concat(new[]{val}).ToArray(); 
               yield return getRows(remainingColumns rowSoFar);
            }
        }
    }
