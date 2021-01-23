    private Int32 CalculatePercentComplete(Int64 totalFileCount, Int64 numFoldersSearched)
        {
            Int32 percentAsInt;
            Decimal searchPercent;
            searchPercent = (Decimal)numFoldersSearched / (Decimal)totalFileCount;
            try
            {
                Decimal x = Math.Round(searchPercent*100, 0, MidpointRounding.ToEven);
                percentAsInt = Convert.ToInt32(x);
            }
            catch (OverflowException oe)
            {
                throw new OverflowException("Error getting percent complete: " + oe.Message, oe);
            }
            if ((percentAsInt < 0) || (percentAsInt > 100))
            {
                throw new ArithmeticException("Invalid percentage: " + percentAsInt);
            }
            return percentAsInt;
        }
