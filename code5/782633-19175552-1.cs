            var listOfRows = new List<List<string>>();
            for (int i = 1; i < columnCount; i++)
            {
                List<string> newRow = new List<string>();
                foreach (var cell in resultList)
                {
                    newRow.Add(cell[i]);
                }
                listOfRows.Add(newRow);
            }
