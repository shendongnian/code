    private void button1_Click(object sender, EventArgs e)
    {
        string barcodeWithoutCzechSum = textBox1.Text.Trim();
        string czechSum = GetBarcodeChecksum(barcodeWithoutCzechSum);
        string barcodeWithCzechSum = string.Format("{0}{1}", barcodeWithoutCzechSum, czechSum);
        label1.Text = barcodeWithCzechSum;
        textBox1.Focus();
    }
    public static string GetBarcodeChecksum(string barcode)
    {
        int oddTotal;
        int oddTotalTripled;
        int evenTotal;
        // Which positions are odd or even depend on the length of the barcode, 
        // or more specifically, whether its length is odd or even, so:
        bool stringOfEvenLength = isStringOfEvenLen(barcode);
        if (stringOfEvenLength)
        {
            oddTotal = sumInsideOrdinals(barcode);
            oddTotalTripled = oddTotal * 3;
            evenTotal = sumOutsideOrdinals(barcode);
        }
        else
        {
            oddTotal = sumOutsideOrdinals(barcode);
            oddTotalTripled = oddTotal * 3;
            evenTotal = sumInsideOrdinals(barcode);
        }
        int finalTotal = oddTotalTripled + evenTotal;
        int modVal = finalTotal%10;
        int czechSum = 10 - modVal;
        if (czechSum == 10)
        {
            return "0";
        }
        return czechSum.ToString();
    }
    private static bool isStringOfEvenLen(string barcode)
    {
        int strLen = barcode.Length;
        return (strLen%2 == 0);
    }
    // "EvenOrdinals" instead of "EvenVals" because values at index 0,2,4,etc. are seen by the 
    // checkdigitmeisters as First, Third, Fifth, ... (etc.), not Zeroeth, Second, Fourth
    private static int sumInsideOrdinals(string barcode)
    {
        int cumulativeVal = 0;
        for (int i = barcode.Length-1; i > -1; i--)
        {
            if (i % 2 != 0)
            {
                cumulativeVal += Convert.ToInt16(barcode[i] - '0');
            }
        }
        return cumulativeVal;
    }
    // "OddOrdinals" instead of "OddVals" because values at index 1,3,5,etc. are seen by the 
    // checkdigitmeisters as Second, Fourth, Sixth, ..., not First, Third, Fifth, ...
    private static int sumOutsideOrdinals(string barcode)
    {
        int cumulativeVal = 0;
        for (int i = barcode.Length - 1; i > -1; i--)
        {
            if (i % 2 == 0)
            {
                cumulativeVal += Convert.ToInt16(barcode[i] - '0');
            }
        }
        return cumulativeVal;
    }
