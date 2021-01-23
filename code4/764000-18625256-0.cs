    0) A button named button1; give it text something like "Calculate barcode and append it to label below", if desired
    1) A button named button2; give it text something like "Valid barcode + czech digit", if desired
    2) A label named label1, which displays the result of clicking button1
    3) A textBox named textBox1, wherein you enter a raw barcode value (sans check digit) prior to clicking button1 OR enter a full barcode value (with check digit) prior to clicking button2
    // "Calculate check sum" handler
    private void button1_Click(object sender, EventArgs e)
    {
        string barcodeWithoutCheckSum = textBox1.Text.Trim();
        string checkSum = GetBarcodeChecksum(barcodeWithoutCheckSum);
        string barcodeWithCheckSum = string.Format("{0}{1}", barcodeWithoutCheckSum, checkSum);
        label1.Text = barcodeWithCheckSum;
        textBox1.Focus();
    }
    
    // Verify/validate existing checksum handler
    private void button2_Click(object sender, EventArgs e)
    {
        string bcVal = textBox1.Text.Trim();
        bool validCheckDigit = isValidBarcodeWithCheckDigit(bcVal);
        MessageBox.Show(validCheckDigit ? string.Format("{0} is valid", bcVal) : string.Format("{0} invalid", bcVal));
    }
    
    public static string GetBarcodeChecksum(string barcode)
    {
        int oddTotal;
        int oddTotalTripled;
        int evenTotal;
        // Which positions are odd or even depend on the length of the barcode, 
        // or more specifically, whether its length is odd or even, so:
        if (isStringOfEvenLen(barcode))
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
        int checkSum = 10 - modVal;
        if (checkSum == 10)
        {
            return "0";
        }
        return checkSum.ToString();
    }
    
    private static bool isStringOfEvenLen(string barcode)
    {
        return (barcode.Length % 2 == 0);
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
    
    private static bool isValidBarcodeWithCheckDigit(string barcodeWithCheckDigit)
    {
        string barcodeSansCheckDigit = barcodeWithCheckDigit.Substring(0, barcodeWithCheckDigit.Length - 1);
        string checkDigit = barcodeWithCheckDigit.Substring(barcodeWithCheckDigit.Length - 1, 1);
        //MessageBox.Show(string.Format("raw barcode portion is {0}", barcodeSansCheckDigit));
        //MessageBox.Show(string.Format("check portion is {0}", checkDigit));
        return GetBarcodeChecksum(barcodeSansCheckDigit) == checkDigit;
    }
