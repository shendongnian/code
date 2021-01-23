        private int? GetMinimumColumnCount(List <RowEntity> dataRows)
        {
            int ? minColumnCount = null;
            
            for (int i = 0; i < dataRows.Count; i++)
            {
                if (minColumnCount == null || minColumnCount > dataRows[i].ColumnValues.Count) 
                {
                    minColumnCount = dataRows[i].ColumnValues.Count; 
                }     
            }
            return minColumnCount; 
        }
