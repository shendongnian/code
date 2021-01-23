    private static string mColumnLetters = "zabcdefghijklmnopqrstuvwxyz";
    // Convert Column name to 1 based index
    public static int ColumnIndexByName(string ColumnName)
        {
            string CurrentLetter;
            int ColumnIndex, LetterValue, ColumnNameLength;
            ColumnIndex = -1; // A is the first column, but for calculation it's number is 1 and not 0. however, Index is alsways zero-based.
            ColumnNameLength = ColumnName.Length;
            for (int i = 0; i < ColumnNameLength; i++)
            {
                CurrentLetter = ColumnName.Substring(i, 1).ToLower();
                LetterValue = mColumnLetters.IndexOf(CurrentLetter);
                ColumnIndex += LetterValue * (int)Math.Pow(26, (ColumnNameLength - (i + 1)));
            }
            return ColumnIndex;
        }
    // Convert 1 based index to Column name
    public static string ColumnNameByIndex(int ColumnIndex)
        {
            int ModOf26, Subtract;
            StringBuilder NumberInLetters = new StringBuilder();
            ColumnIndex += 1; // A is the first column, but for calculation it's number is 1 and not 0. however, Index is alsways zero-based.
            while (ColumnIndex > 0)
            {
                if (ColumnIndex <= 26)
                {
                    ModOf26 = ColumnIndex;
                    NumberInLetters.Insert(0, mColumnLetters.Substring(ModOf26, 1));
                    ColumnIndex = 0;
                }
                else
                {
                    ModOf26 = ColumnIndex % 26;
                    Subtract = (ModOf26 == 0) ? 26 : ModOf26;
                    ColumnIndex = (ColumnIndex - Subtract) / 26;
                    NumberInLetters.Insert(0, mColumnLetters.Substring(ModOf26, 1));
                }
            }
            return NumberInLetters.ToString().ToUpper();
        }
