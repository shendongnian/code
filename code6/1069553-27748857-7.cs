    public void Add(LargeDecimal other)
    {
        if (other == null) return;
        if (IsNegative != other.IsNegative)
        {
            // Get the absolue values of the two operands
            var absThis = new LargeDecimal(this) {IsNegative = false};
            var absOther = new LargeDecimal(other) {IsNegative = false};
            // If the signs are different and the values are the same, reset to 0.
            if (absThis == absOther)
            {
                ResetToZero();
                return;
            }
            // Since the signs are different, we will retain the sign of the larger number
            IsNegative = absThis < absOther ? other.IsNegative : IsNegative;
            // Assign the difference of the two absolute values
            absThis.Subtract(absOther);
            wholeDigits = absThis.wholeDigits.GetRange(0, absThis.wholeDigits.Count);
            decimalDigits = absThis.decimalDigits.GetRange(0, absThis.decimalDigits.Count);
            NormalizeLists();
            return;
        }
        // start with the larger decimal digits list
        var newDecimalDigits = new List<int>();
        newDecimalDigits = decimalDigits.Count > other.decimalDigits.Count
            ? decimalDigits.GetRange(0, decimalDigits.Count)
            : other.decimalDigits.GetRange(0, other.decimalDigits.Count);
        // and add the smaller one to it
        int carry = 0;
        for (int i = Math.Min(decimalDigits.Count, other.decimalDigits.Count) - 1; i >= 0; i--)
        {
            var result = decimalDigits[i] + other.decimalDigits[i] + carry;
            carry = Convert.ToInt32(Math.Floor((decimal) result / 10));
            result = result % 10;
            newDecimalDigits[i] = result;
        }
        var newWholeDigits = new List<int>();
        newWholeDigits = wholeDigits.Count > other.wholeDigits.Count
            ? wholeDigits.GetRange(0, wholeDigits.Count)
            : other.wholeDigits.GetRange(0, other.wholeDigits.Count);
        for (int i = Math.Min(wholeDigits.Count, other.wholeDigits.Count) - 1; i >= 0; i--)
        {
            var result = wholeDigits[i] + other.wholeDigits[i] + carry;
            carry = Convert.ToInt32(Math.Floor((decimal)result / 10));
            result = result % 10;
            newWholeDigits[i] = result;
        }
        if (carry > 0) newWholeDigits.Insert(0, carry);
        wholeDigits = newWholeDigits.GetRange(0, newWholeDigits.Count);
        decimalDigits = newDecimalDigits.GetRange(0, newDecimalDigits.Count);
        NormalizeLists();
    }
    public void Subtract(LargeDecimal other)
    {
        if (other == null) return;
        // If the other value is the same as this one, then the difference is zero
        if (Equals(other))
        {
            ResetToZero();
            return;
        }
        // Absolute values will be used to determine how we subtract
        var absThis = new LargeDecimal(this) {IsNegative = false};
        var absOther = new LargeDecimal(other) {IsNegative = false};
        // If the signs are different, then the difference will be the sum
        if (IsNegative != other.IsNegative)
        {
            absThis.Add(absOther);
            wholeDigits = absThis.wholeDigits.GetRange(0, absThis.wholeDigits.Count);
            decimalDigits = absThis.decimalDigits.GetRange(0, absThis.decimalDigits.Count);
            NormalizeLists();
            return;
        }
        // Subtract smallNumber from bigNumber to get the difference
        LargeDecimal bigNumber;
        LargeDecimal smallNumber;
        if (absThis < absOther)
        {
            if (absThis.IsNegative) IsNegative = false;
            bigNumber = new LargeDecimal(absOther);
            smallNumber = new LargeDecimal(absThis);
        }
        else
        {
            bigNumber = new LargeDecimal(absThis);
            smallNumber = new LargeDecimal(absOther);
        }
        // Pad the whole number and decimal number lists where necessary so that 
        // both numbers have the same count of whole and decimal numbers. In other words:
        AddTrailingZeroes(
            bigNumber.decimalDigits.Count < smallNumber.decimalDigits.Count
                ? bigNumber.decimalDigits
                : smallNumber.decimalDigits,
            Math.Abs(bigNumber.decimalDigits.Count - smallNumber.decimalDigits.Count));
        AddLeadingZeroes(smallNumber.wholeDigits,
            Math.Abs(bigNumber.wholeDigits.Count - smallNumber.wholeDigits.Count));
        var newWholeDigits = new List<int>();
        var newDecimalDigits = new List<int>();
        bool borrowed = false; // True if we borrowed 1 from next number
        for (int i = bigNumber.decimalDigits.Count - 1; i >= 0; i--)
        {
            if (borrowed)
            {
                bigNumber.decimalDigits[i] -= 1; // We borrowed one from this number last time
                borrowed = false;
            }
            if (bigNumber.decimalDigits[i] < smallNumber.decimalDigits[i])
            {
                bigNumber.decimalDigits[i] += 10; // Borrow from next number and add to this one
                borrowed = true;
            }
            // Since we're working from the back of the list, always add to the front
            newDecimalDigits.Insert(0, bigNumber.decimalDigits[i] - smallNumber.decimalDigits[i]);
        }
        for (int i = bigNumber.wholeDigits.Count - 1; i >= 0; i--)
        {
            if (borrowed)
            {
                bigNumber.wholeDigits[i] -= 1;
                borrowed = false;
            }
            if (bigNumber.wholeDigits[i] < smallNumber.wholeDigits[i])
            {
                bigNumber.wholeDigits[i] += 10;
                borrowed = true;
            }
            newWholeDigits.Insert(0, bigNumber.wholeDigits[i] - smallNumber.wholeDigits[i]);
        }
        if (absThis < absOther) IsNegative = !IsNegative;
        wholeDigits = newWholeDigits.GetRange(0, newWholeDigits.Count);
        decimalDigits = newDecimalDigits.GetRange(0, newDecimalDigits.Count);
        NormalizeLists();
    }
