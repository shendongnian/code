        private static CspTerm[] GetRow(CspTerm[][] matrix, int row)
        {
            CspTerm[] slice = new CspTerm[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
                slice[col] = matrix[row][col];
            return slice;
        }
