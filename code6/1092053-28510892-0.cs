            var query = Enumerable.Range(0, results.GetLength(1))
                .Select(iCol => Enumerable.Range(0, results.GetLength(0))
                    .Select(iRow => results[iRow, iCol])
                    .Where(d => !double.IsNaN(d))
                    .Percentile(90));
