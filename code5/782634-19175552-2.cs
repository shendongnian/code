            for (int i = 1; i < rowCount; i++)
            {
                var newRow = new List<string>();
                foreach (var cell in list)
                {
                    newRow.Add(cell[i]);
                }
                yield return newRow;
            }
