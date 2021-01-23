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
        int oddTotal = sumOddVals(barcode);
        int oddTotalTripled = oddTotal*3;
        int evenTotal = sumEvenVals(barcode);
        int finalTotal = oddTotalTripled + evenTotal;
        int modVal = finalTotal%10;
        int czechSum = 10 - modVal;
        if (czechSum == 10)
        {
            return "0";
        }
        return czechSum.ToString();
    }
    private static int sumEvenVals(string barcode)
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
    private static int sumOddVals(string barcode)
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
