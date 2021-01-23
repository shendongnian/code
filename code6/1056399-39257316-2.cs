    void ForEachPermutationDo<T>(IEnumerable<IEnumerable<T>> listOfList, Func<IEnumerable<T>, bool> whatToDo) {
        var numCols = listOfList.Count();
        var numRows = listOfList.Aggregate(1, (a, b) => a * b.Count());
        var continueGenerating = true;
        
        var permutation = new List<T>();
        for (var r = 0; r < numRows; r++) {
            var repeatFactor = 1;
            for (var c = 0; c < numCols; c++) {
                var aList = listOfList.ElementAt(c);
                permutation.Add(aList.ElementAt((r / repeatFactor) % aList.Count()));
                repeatFactor *= aList.Count();
            }
            
            continueGenerating = whatToDo(permutation.ToList()); // send duplicate
            if (!continueGenerating) break;
            
            permutation.Clear();
        }
    }
