    public static class VAT
    {
        /// <summary>
        /// Validates a GB VAT number
        /// </summary>
        public static bool ValidateGBVatNumber(string vatNumber)
        {
            vatNumber = vatNumber.Replace(" ", "").ToUpperInvariant();
            if (vatNumber.Length == 11)
            {
                if (vatNumber[0] == 'G' && vatNumber[1] == 'B')
                {
                    vatNumber = vatNumber.Substring(2);
                }
                else
                {
                    // First digits are not GB
                    return false;
                }
            }
            if (vatNumber.Length != 9)
            {
                // Wrong length even after removing spaces and getting rid of the first two characters
                return false;
            }
            // Provided number has 9 digits, which is correct. Proceed to calculate checksum
            int runningTotal = 0;
            int[] multipliersByIndex = new int[] {8, 7, 6, 5, 4, 3, 2};
            for (int i = 0; i < 7; i++)
            {
                int currentDigitValue;
                if (!int.TryParse(vatNumber[i].ToString(), out currentDigitValue))
                {
                    // Could not parse a digit into an int => wrong character supplied
                    return false;
                }
                runningTotal += currentDigitValue * multipliersByIndex[i];
            }
            // Subtract 97 until negative - this could perhaps be better done with the modulus operator
            // but this way might be more 'obvious'
            while (runningTotal >= 0)
            {
                runningTotal -= 97;
            }
            // Convert to a string that will have two digits even if the number only has one
            string checkSum = (runningTotal * -1).ToString("00");
            return (checkSum[0] == vatNumber[7] && checkSum[1] == vatNumber[8]);
        }
    }
